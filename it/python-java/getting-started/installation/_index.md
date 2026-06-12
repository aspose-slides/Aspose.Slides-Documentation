---
title: Installazione
type: docs
weight: 70
url: /it/python-java/installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione di Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Installa Aspose.Slides for Python via Java su Windows, Linux o macOS"
---
Aspose.Slides for Python via Java è un'API indipendente dalla piattaforma e può essere utilizzata su qualsiasi piattaforma (Windows, Linux e MacOS) dove sono installati `Python`, `Java` e il bridge `jpype1`.

## **Requisiti per programmi e versioni**

Per garantire il corretto funzionamento di Aspose.Slides for Python via Java, è necessario installare i seguenti programmi e pacchetti:

- Versione JRE >=8 (JPype1 è stato testato su versioni Java dalla 1.8 alla 11).
- Versione Python >=3.7,<=3.12.
- Versione del pacchetto JPype1: >=1.5.0.

## **Installa da pip**

È possibile installare facilmente Aspose.Slides for Python via Java da [pip](https://pypi.org/) purché siano installati tutti i programmi richiesti (Java, Python).

Crea una nuova cartella di progetto.

[Installa JPype1](https://jpype.readthedocs.io/en/latest/install.html) usando il seguente comando:
```
$ pip install JPype1
```

Installa Aspose.Slides for Python via Java usando il seguente comando:
```
$ pip install aspose-slides-java
```

## **Installa da archivio ZIP**

Per installare e utilizzare Aspose.Slides for Python via Java da un archivio ZIP, segui queste istruzioni:

### **Windows**

1. Installa JDK8 e configura la variabile d'ambiente `JAVA_HOME`.
2. [Installa Python](https://www.python.org/downloads/) versione >=3.7 e aggiungi python.exe al `PATH`.
3. [Installa Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Installa JPype1](https://jpype.readthedocs.io/en/latest/install.html). È possibile eseguire i comandi seguenti nel terminale python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Scarica Aspose.Slides for Python via Java](https://releases.aspose.com/slides/it/python-java/) ed estrailo in `aspose-slides-java`.
6. Crea un file chiamato `example.py` nella cartella `aspose-slides-java` usando il seguente codice di esempio:
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
7. Ora esegui `py example.py` @command prompt per avviarlo.

### **Linux**

1. Installa JDK8 per Linux e configura la variabile d'ambiente `JAVA_HOME`.
2. [Installa Python](https://www.python.org/downloads/) versione >=3.7
3. Installa ``g++`` e ``python-dev``. 

- Per Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Per RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Installa JPype1](https://jpype.readthedocs.io/en/latest/install.html). È possibile eseguire i comandi seguenti nel terminale python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Scarica Aspose.Slides for Python via Java](https://releases.aspose.com/slides/it/python-java/) ed estrailo in `aspose-slides-java`.
6. Crea un file di test chiamato `example.py` usando questo codice di esempio nella cartella `aspose-slides-java`:
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
7. Ora esegui `py example.py` @command prompt per avviarlo.

### **Mac**

1. Installa JDK8 per Mac e configura la variabile d'ambiente `JAVA_HOME`.
2. Modifica la sezione JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` con privilegi di root. `jdk1.8.x_xxx.jdk` dipende dalla tua versione JDK. Fallo apparire così:
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
3. [Installa Python](https://www.python.org/downloads/) versione >=3.7.
4. Installa i compilatori GCC o Clang a seconda della versione di Python e della piattaforma.
5. [Installa JPype1](https://jpype.readthedocs.io/en/latest/install.html). È possibile eseguire i comandi seguenti nel terminale python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Scarica Aspose.Slides for Python via Java](https://releases.aspose.com/slides/it/python-java/) ed estrailo in `aspose-slides-java`.
7. Crea un file di test chiamato `example.py` usando questo codice di esempio nella cartella `aspose-slides-java`:
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
9. Ora esegui `python example.py` @command prompt per avviarlo.