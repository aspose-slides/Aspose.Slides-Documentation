---
title: Πώς να Εκτελέσετε το Aspose.Slides για Java σε Docker
type: docs
weight: 75
url: /el/java/how-to-run-aspose-slides-in-docker/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- συμβατότητα πολλαπλών πλατφορμών
- απομόνωση εξαρτήσεων
- απλοποιημένη ανάπτυξη
- ρύθμιση έργου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εκτελέστε το Aspose.Slides σε κοντέινερ Docker: διαμορφώστε εικόνες, εξαρτήσεις, γραμματοσειρές και άδειες χρήσης για να δημιουργήσετε κλιμακούμενες υπηρεσίες που επεξεργάζονται PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Αυτός ο οδηγός εξηγεί πώς να δημιουργήσετε ένα κοντέινερ για μια εφαρμογή Java χρησιμοποιώντας το Aspose Slides με Docker. Κύρια οφέλη περιλαμβάνουν:

- **Συμβατότητα πολλαπλών πλατφορμών** - Λειτουργεί σε Windows, macOS και Linux
- **Απομόνωση εξαρτήσεων** - Δεν απαιτούνται εγκαταστάσεις σε όλο το σύστημα
- **Απλοποιημένη ανάπτυξη** - Εύκολη κοινή χρήση και εκτέλεση

## **1. Εγκατάσταση Docker**

### **Windows**

**Απαιτήσεις:**

- Windows 10/11 Pro/Enterprise/Education (64‑bit) με ενεργοποιημένο WSL 2
- Για έκδοση Home: Απαιτείται χειροκίνητη εγκατάσταση του WSL 2

**Βήματα:**

1. Κατεβάστε το [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Εκτελέστε το πρόγραμμα εγκατάστασης και ακολουθήστε τον οδηγό ρυθμίσεων
3. Επανεκκινήστε τον υπολογιστή σας όταν ζητηθεί
4. Επαληθεύστε την εγκατάσταση:
   ```powershell
   docker --version
   ```

### **macOS**

**Requirements:**

- macOS 10.15 (Catalina) or newer
- Apple Silicon or Intel processor

**Steps:**

1. Download the [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Drag the application to your `Applications` folder
3. Launch Docker and wait for initialization
4. Verify installation:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Installation:**

```bash
# Update package lists
sudo apt update && sudo apt upgrade -y

# Install prerequisites
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Add Docker's official GPG key
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Add a stable repository
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Install the Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Allow the current user to run Docker commands
sudo usermod -aG docker $USER
newgrp docker

# Verify installation
docker --version
```

## **2. Dockerfile Configuration**

### **Base Image**

```dockerfile
FROM ubuntu:24.04
```
> **Note**: Uses the [official Ubuntu image](https://hub.docker.com/_/ubuntu) from Docker Hub.

### **Dependencies**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java runtime environment
- **Font packages**: Includes Microsoft Core Fonts

### **Aspose.Slides Setup**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Version-pinned download of Aspose Slides library

## **3. Project Setup**

### **File Structure**

```
aspose-docker/
├── Dockerfile          # Container configuration
├── TestAspose.java     # Application code
└── output/             # Folder with generated PDFs (auto-created)
```
### **Dockerfile**
Create a file named `Dockerfile` with:
```dockerfile
FROM ubuntu:24.04

# Set environment variables
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Create a working directory
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Install dependencies
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configure fonts
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Download Aspose.Slides to /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Copy the source code
COPY TestAspose.java ${APP_DIR}/

# Create the run script
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Explicitly grant execute permissions to the script
RUN chmod 755 ${APP_DIR}/run.sh

# Compile the Java code
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Set the working directory
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java Application**

Create `TestAspose.java` with:
```java
import com.aspose.slides.*;

public class TestAspose {
    public static void main(String[] args) throws Exception {
        System.out.println("Creating presentation...");
        
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 190, 300, 25);
            autoShape.getTextFrame().setText("Greetings from Docker!");
            
            presentation.save("/tmp/output/output.pdf", SaveFormat.Pdf);
        } finally {
            if (presentation != null) presentation.dispose();
        }
        System.out.println("Presentation saved as output.pdf");
    }
}
```

## **4. Δημιουργία και Εκτέλεση**

### **Δημιουργία της Εικόνας**

   Εκτελέστε την παρακάτω εντολή στον φάκελο που βρίσκεται το Dockerfile για να δημιουργήσετε την εικόνα Docker:
   ```powershell
   docker build -t aspose-test .
   ```
   
- `-t` ορίζει το όνομα της εικόνας "aspose-test"
- `.` χρησιμοποιεί το Dockerfile του τρέχοντος καταλόγου

### **Εκτέλεση του Container**

   Εκτελέστε την παρακάτω εντολή στον φάκελο που βρίσκεται το Dockerfile για να τρέξετε το κοντέινερ Docker:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
   
- `-v` προσαρτά τον φάκελο εξόδου
- Δημιουργεί το `output.pdf` στο τοπικό φάκελο `output`