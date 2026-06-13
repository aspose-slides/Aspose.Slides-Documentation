---
title: Docker में Aspose.Slides for Java चलाने का तरीका
type: docs
weight: 75
url: /hi/java/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides की स्थापना
- Docker
- Windows
- macOS
- Linux
- क्रॉस‑प्लैटफ़ॉर्म संगतता
- निर्भरता अलगाव
- सरलीकृत परिनियोजन
- परियोजना सेटअप
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Docker कंटेनरों में Aspose.Slides चलाएँ: इमेजेज़, निर्भरताएँ, फ़ॉन्ट और लाइसेंसिंग को कॉन्फ़िगर करके स्केलेबल सेवाएँ बनाएँ जो PowerPoint और OpenDocument को प्रोसेस करती हैं।"
---
## **परिचय**

यह गाइड बताता है कि कैसे Aspose Slides के साथ Docker का उपयोग करके Java एप्लिकेशन को कंटेनराइज़ किया जाए। प्रमुख लाभ शामिल हैं:

- **क्रॉस‑प्लैटफ़ॉर्म संगतता** - Windows, macOS, और Linux पर चलता है
- **निर्भरता पृथक्करण** - सिस्टम‑व्यापी इंस्टॉलेशन की आवश्यकता नहीं
- **सरलीकृत डिप्लॉयमेंट** - आसान शेयरिंग और निष्पादन

## **1. Docker स्थापना**

### **Windows**

**आवश्यकताएँ:**

- Windows 10/11 Pro/Enterprise/Education (64‑बिट) जिसमें WSL 2 सक्षम हो
- Home संस्करण के लिए: मैन्युअल WSL 2 इंस्टॉलेशन आवश्यक है

**कदम:**

1. डाउनलोड करें [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. इंस्टॉलर चलाएँ और सेटअप विज़ार्ड का पालन करें
3. जब संकेत मिले तो कंप्यूटर रीस्टार्ट करें
4. स्थापना सत्यापित करें:
   ```powershell
   docker --version
   ```

### **macOS**

**आवश्यकताएँ:**

- macOS 10.15 (Catalina) या नया
- Apple Silicon या Intel प्रोसेसर

**कदम:**

1. डाउनलोड करें [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. एप्लिकेशन को अपने `Applications` फ़ोल्डर में ड्रैग करें
3. Docker लॉन्च करें और इनिशियलाइज़ेशन का इंतजार करें
4. स्थापना सत्यापित करें:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**स्थापना:**
```bash
# पैकेज सूचियों को अपडेट करें
sudo apt update && sudo apt upgrade -y

# पूर्वापेक्षाएँ स्थापित करें
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Docker की आधिकारिक GPG कुंजी जोड़ें
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# स्थिर रिपॉजिटरी जोड़ें
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Docker इंजन स्थापित करें
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# वर्तमान उपयोगकर्ता को Docker कमांड चलाने की अनुमति दें
sudo usermod -aG docker $USER
newgrp docker

# स्थापना सत्यापित करें
docker --version
```

## **2. Dockerfile विन्यास**

### **बेस इमेज**

```dockerfile
FROM ubuntu:24.04
```
> **नोट**: Docker Hub से [official Ubuntu image](https://hub.docker.com/_/ubuntu) का उपयोग करता है।

### **निर्भरताएँ**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java रनटाइम वातावरण
- **Font packages**: Microsoft Core Fonts शामिल हैं

### **Aspose.Slides सेटअप**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Aspose Slides लाइब्रेरी का संस्करण‑स्पेसिफिक डाउनलोड

## **3. प्रोजेक्ट सेटअप**

### **फ़ाइल स्ट्रक्चर**

```
aspose-docker/
├── Dockerfile          # कंटेनर विन्यास
├── TestAspose.java     # एप्लिकेशन कोड
└── output/             # उत्पन्न PDF फाइलों वाला फ़ोल्डर (स्वतः बनाया गया)
```

### **Dockerfile**

नाम `Dockerfile` वाली फ़ाइल बनाएं:
```dockerfile
FROM ubuntu:24.04

# पर्यावरण वेरिएबल सेट करें
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# वर्किंग डायरेक्टरी बनाएं
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# निर्भरताएँ स्थापित करें
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# फ़ॉन्ट कॉन्फ़िगर करें
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Aspose.Slides को /tmp पर डाउनलोड करें
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# स्रोत कोड कॉपी करें
COPY TestAspose.java ${APP_DIR}/

# रन स्क्रिप्ट बनाएं
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# स्पष्ट रूप से स्क्रिप्ट को निष्पादन अनुमति दें
RUN chmod 755 ${APP_DIR}/run.sh

# Java कोड संकलित करें
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# वर्किंग डायरेक्टरी सेट करें
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java Application**

`TestAspose.java` बनाएं जिसमें:
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

## **4. बिल्डिंग और रनिंग**

### **इमेज बनाएं**

Dockerfile स्थित डायरेक्टरी में नीचे दिया गया कमांड चलाएँ ताकि Docker इमेज बना सकें:
```powershell
   docker build -t aspose-test .
   ```

- `-t` इमेज का नाम "aspose-test" रखता है
- `.` वर्तमान डायरेक्टरी के Dockerfile का उपयोग करता है

### **कंटेनर चलाएं**

Dockerfile स्थित डायरेक्टरी में नीचे दिया गया कमांड चलाएँ ताकि Docker कंटेनर चल सके:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` आउटपुट डायरेक्टरी को माउंट करता है
- आपके स्थानीय `output` फ़ोल्डर में `output.pdf` बनाता है