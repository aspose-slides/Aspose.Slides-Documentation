---
title: Instalação
type: docs
weight: 70
url: /pt/nodejs-java/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Instale o Aspose.Slides para Node.js via Java a partir do npm no Windows, Linux e macOS: o JDK, Python e as ferramentas de compilação C++ que ele precisa, o comando npm e um primeiro script para verificar a instalação."
---
## **Visão geral**

Este artigo explica como instalar o Aspose.Slides for Node.js via Java no Windows, Linux e macOS, e como verificar se a instalação funciona.

O Aspose.Slides for Node.js via Java é distribuído como o pacote `aspose.slides.via.java` no npm. Ele executa o Aspose.Slides em uma máquina virtual Java através do pacote [`java`](https://github.com/joeferner/node-java), um addon nativo do Node.js que o npm compila no seu computador durante a instalação. Por isso a instalação necessita, além do Node.js:

- **Um Kit de Desenvolvimento Java (JDK) 8 ou posterior.** Apenas o runtime Java não é suficiente: a compilação precisa dos arquivos de cabeçalho do JDK.
- **Python 3**, que a ferramenta de compilação [node-gyp](https://github.com/nodejs/node-gyp) usa.
- **Uma cadeia de ferramentas de compilação C++** para o seu sistema operacional.

## **Instalar os pré‑requisitos**

### **Windows**

1. Instale o [Node.js](https://nodejs.org/en/download) 20 ou posterior.
2. Instale um JDK, por exemplo o [Eclipse Temurin](https://adoptium.net/), e configure a variável de ambiente `JAVA_HOME` apontando para sua pasta de instalação. A compilação usa o JDK ao qual `JAVA_HOME` aponta.
3. Instale o [Python 3](https://www.python.org/downloads/).
4. Instale o [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) com a carga de trabalho **Desktop development with C++**. Mantenha os componentes padrão da carga de trabalho, que incluem **MSVC v143 - VS 2022 C++ x64/x86 build tools** e o **Windows 11 SDK**. O Visual Studio 2026 não funciona: a versão do node-gyp que o pacote `java` compila não o reconhece.

### **Linux**

Instale o Node.js 20 ou posterior a partir de [nodejs.org](https://nodejs.org/en/download) ou da fonte de pacotes da sua distribuição. Em seguida, instale um JDK, Python 3 e as ferramentas de compilação C++. No Debian e Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

No Linux, a compilação encontra o JDK instalado sem necessidade de configuração adicional. Se vários JDKs estiverem instalados, defina `JAVA_HOME` para aquele que deseja usar.

### **macOS**

Instale o Node.js 20 ou posterior, um JDK e as Ferramentas de Linha de Comando do Xcode, que incluem Python 3 e o compilador C++. Veja [Troubleshooting Installation](/slides/pt/nodejs-java/troubleshooting-installation/) para notas específicas do macOS.

## **Instalar via npm**

Crie uma pasta de projeto e instale o pacote:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm baixa o Aspose.Slides e compila a ponte `java`, o que pode levar alguns minutos. Se a compilação falhar, consulte [Troubleshooting Installation](/slides/pt/nodejs-java/troubleshooting-installation/).

## **Verificar a instalação**

Crie um arquivo chamado *hello.js* na pasta do projeto com o seguinte código. Ele cria uma apresentação, adiciona uma caixa de texto ao seu primeiro slide e salva o resultado como *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides executa em uma máquina virtual Java que mantém o Node.js em execução, portanto encerre o processo explicitamente.
process.exit(0);
```

Execute o script:

```bash
node hello.js
```

Se *hello.pptx* aparecer na pasta do projeto, a instalação funciona. A máquina virtual Java que executa o Aspose.Slides impede que o Node.js encerre por conta própria, por isso o script termina com `process.exit(0)`. [Create Presentations](/slides/pt/nodejs-java/create-presentation/) explica o código.

## **Instalar a partir de um arquivo ZIP**

O pacote também está disponível como um arquivo ZIP com o mesmo conteúdo do pacote npm. Para instalá‑lo a partir do arquivo:

1. Instale os pré‑requisitos para o seu sistema operacional, conforme descrito acima.
2. Baixe o arquivo da [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/pt/nodejs-java/).
3. Crie uma pasta de projeto:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Extraia o arquivo para uma subpasta chamada *aspose.slides.via.java* dentro da pasta do projeto, de modo que o *package.json* do arquivo fique em *hello-slides/aspose.slides.via.java/package.json*.
5. Instale o pacote a partir dessa pasta:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm instala a ponte `java` da qual o pacote depende e a compila, como faz para o pacote npm.

6. Verifique a instalação conforme descrito em [Check the Installation](#check-the-installation).

## **FAQ**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim. Sem uma licença, o Aspose.Slides funciona em modo de avaliação: ele adiciona uma marca d'água de avaliação a cada slide que salva e trunca o texto lido das apresentações. Para remover essas limitações, aplique uma [license](/slides/pt/nodejs-java/licensing/) válida.

**Por que meu script não sai depois de terminar?**

O pacote `java` inicia uma máquina virtual Java dentro do processo Node.js, e essa máquina virtual mantém o processo em execução. Chame `process.exit` quando seu script terminar o trabalho.