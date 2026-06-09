---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/python-java/installation/
keywords:
- Λήψη Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Εγκατάσταση του Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Εγκαταστήστε το Aspose.Slides for Python via Java στα Windows, Linux ή macOS"
---
Aspose.Slides for Python via Java είναι API ανεξάρτητο από πλατφόρμα και μπορεί να χρησιμοποιηθεί σε οποιαδήποτε πλατφόρμα (Windows, Linux και MacOS) όπου είναι εγκατεστημένα τα `Python`, `Java` και η γέφυρα `jpype1`.

## **Απαιτήσεις για προγράμματα και εκδόσεις**

Για να εξασφαλιστεί η σωστή λειτουργία του Aspose.Slides for Python via Java, πρέπει να εγκατασταθούν τα παρακάτω προγράμματα και πακέτα:

- Έκδοση JRE >=8 (Το JPype1 έχει δοκιμαστεί σε εκδόσεις Java από 1.8 έως 11).
- Έκδοση Python >=3.7, <=3.12.
- Έκδοση πακέτου JPype1: >=1.5.0.

## **Εγκατάσταση από pip**

Μπορείτε εύκολα να εγκαταστήσετε το Aspose.Slides for Python via Java από το [pip](https://pypi.org/) εφόσον έχετε εγκατεστημένα όλα τα απαιτούμενα προγράμματα (Java, Python).

Δημιουργήστε ένα νέο φάκελο έργου.

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) χρησιμοποιώντας την παρακάτω εντολή:
```
$ pip install JPype1
```

Εγκαταστήστε το Aspose.Slides for Python via Java χρησιμοποιώντας την παρακάτω εντολή:
```
$ pip install aspose-slides-java
```

## **Εγκατάσταση από αρχείο ZIP**

Για να εγκαταστήσετε και να χρησιμοποιήσετε το Aspose.Slides for Python via Java από ένα αρχείο ZIP, ακολουθήστε αυτές τις οδηγίες:

### **Windows**

1. Εγκαταστήστε το JDK8 και ρυθμίστε τη μεταβλητή περιβάλλοντος `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) έκδοση >=3.7 και προσθέστε το python.exe στο `PATH`.
3. [Install Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). Μπορείτε να εκτελέσετε τις παρακάτω εντολές στο τερματικό python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/el/python-java/) και εξάγετε το στο `aspose-slides-java`.
6. Δημιουργήστε ένα αρχείο με όνομα `example.py` στον φάκελο `aspose-slides-java` χρησιμοποιώντας τον παρακάτω κώδικα παραδείγματος:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Τώρα εκτελέστε `py example.py` στη γραμμή εντολών για να το τρέξετε.

### **Linux**

1. Εγκαταστήστε το JDK8 για Linux και ρυθμίστε τη μεταβλητή περιβάλλοντος `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) έκδοση >=3.7
3. Εγκαταστήστε ``g++`` και ``python-dev``. 

- Για Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- For RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/el/python-java/) and extract it to `aspose-slides-java`.
6. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Now run `py example.py` @command prompt to run it.

### **Mac**

1. Install JDK8 for Mac and configure `JAVA_HOME` environment variable.
2. Modify JVMCapabilities section in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` with root privilege. `jdk1.8.x_xxx.jdk` depends on your jdk version. Make it look like this:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Install Python](https://www.python.org/downloads/) version >=3.7.
4. Install GCC or Clang compilers depending on the Python`s version and platform.
5. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/el/python-java/) and extract it into `aspose-slides-java`.
7. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Τώρα εκτελέστε `python example.py` στη γραμμή εντολών για να το τρέξετε.