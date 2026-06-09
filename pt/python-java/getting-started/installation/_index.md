---
title: Instalação
type: docs
weight: 70
url: /pt/python-java/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- Instalação do Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Instale o Aspose.Slides for Python via Java no Windows, Linux ou macOS"
---
Aspose.Slides for Python via Java é uma API independente de plataforma e pode ser usada em qualquer plataforma (Windows, Linux e MacOS) onde `Python`, `Java` e a ponte `jpype1` estejam instalados.

## **Requisitos para programas e versões**

Para garantir o funcionamento adequado do Aspose.Slides for Python via Java, os seguintes programas e pacotes devem ser instalados:

- Versão do JRE >=8 (JPype1 foi testado nas versões do Java de 1.8 a 11).
- Versão do Python >=3.7, <=3.12.
- Versão do pacote JPype1: >=1.5.0.

## **Instalar via pip**

Você pode instalar facilmente o Aspose.Slides for Python via Java a partir do [pip](https://pypi.org/) desde que todos os programas necessários (Java, Python) estejam instalados.

Crie uma nova pasta de projeto.

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) usando o seguinte comando:
```
$ pip install JPype1
```

Instale Aspose.Slides for Python via Java usando o seguinte comando:
```
$ pip install aspose-slides-java
```

## **Instalar a partir de arquivo ZIP**

Para instalar e usar o Aspose.Slides for Python via Java a partir de um arquivo ZIP, siga estas instruções:

### **Windows**

1. Instale o JDK8 e configure a variável de ambiente `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) versão >=3.7 e adicione python.exe ao `PATH`.
3. [Install Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). Você pode executar os comandos abaixo no terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pt/python-java/) e extraia-o para `aspose-slides-java`.
6. Crie um arquivo chamado `example.py` na pasta `aspose-slides-java` usando o código de exemplo a seguir:

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

7. Agora execute `py example.py` no prompt de comando para executá‑lo.

### **Linux**

1. Instale o JDK8 para Linux e configure a variável de ambiente `JAVA_HOME`.
2. [Install Python](https://www.python.org/downloads/) versão >=3.7
3. Instale ``g++`` e ``python-dev``. 

- Para Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Para distribuições baseadas em RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). Você pode executar os comandos abaixo no terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pt/python-java/) e extraia-o para `aspose-slides-java`.
6. Crie um arquivo de teste chamado `example.py` usando este código de exemplo na pasta `aspose-slides-java`:

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
7. Agora execute `py example.py` no prompt de comando para executá‑lo.

### **Mac**

1. Instale o JDK8 para Mac e configure a variável de ambiente `JAVA_HOME`.
2. Modifique a seção JVMCapabilities em `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` com privilégios de administrador. `jdk1.8.x_xxx.jdk` depende da sua versão do jdk. Deixe assim:
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
3. [Install Python](https://www.python.org/downloads/) versão >=3.7.
4. Instale compiladores GCC ou Clang dependendo da versão do Python e da plataforma.
5. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). Você pode executar os comandos abaixo no terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pt/python-java/) e extraia-o em `aspose-slides-java`.
7. Crie um arquivo de teste chamado `example.py` usando este código de exemplo na pasta `aspose-slides-java`:

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
9. Agora execute `python example.py` no prompt de comando para executá‑lo.