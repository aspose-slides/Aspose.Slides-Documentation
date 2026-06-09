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
description: "Aprenda a instalar rapidamente o Aspose.Slides. Guia passo a passo, requisitos de sistema e exemplos de código — comece a trabalhar com apresentações PowerPoint hoje!"
---
## **Introdução**

Aspose.Slides for Node.js via Java é uma API independente de plataforma e pode ser usada em qualquer plataforma (Windows, Linux e macOS) onde `Node.js` e a ponte [`java`](https://www.npmjs.com/package/java) estejam instalados.

## **Instalar via NPM**

Você pode instalar facilmente Aspose.Slides for Node.js via Java a partir do [NPM](https://www.npmjs.com/).

1. Crie uma nova pasta e inicie um novo projeto usando o seguinte comando:
	```
	$ npm init
	```
	
2. Preencha os campos de título e versão (deixe os demais campos com seus valores padrão).

3. Instale Aspose.Slides for Node.js via Java usando o seguinte comando:
	```
	$ npm install aspose.slides.via.java
	```

Se encontrar algum problema durante o processo de instalação, consulte este [artigo](/slides/pt/nodejs-java/troubleshooting-installation/).

**Exemplo de Uso**:

Crie um arquivo chamado `hello.js` na pasta do seu projeto e adicione o seguinte código de exemplo:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Instalar a partir de arquivo ZIP**

Para instalar e usar Aspose.Slides for Node.js via Java a partir de um arquivo ZIP, siga estas instruções:

### **Windows**

1. Instale o JDK8 e configure a variável de ambiente `JAVA_HOME`.
1. Instale o Node.js (https://nodejs.org/en/download/) e adicione node.exe ao `PATH`.
1. Instale o node-gyp.
1. Instale o Windows Build Tools.
1. Instale a ponte [`java`](https://www.npmjs.com/package/java) e execute estes comandos no Prompt de Comando como administrador:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Baixe Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pt/nodejs-java/) e extraia-o para `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Crie um arquivo chamado `hello.js` na pasta `aspose.slides.nodejs` usando o seguinte código de exemplo:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Agora execute `node hello.js` no prompt de comando para rodá-lo.

### **Linux**

1. Instale o Node.js (https://nodejs.org/en/download/).
1. Instale o JDK8 para Linux e configure a variável de ambiente `JAVA_HOME`.
1. Instale o python 2.x
1. Instale a ponte [`java`](https://www.npmjs.com/package/java). Você pode executar esses comandos no terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Baixe Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pt/nodejs-java/) e extraia-o para `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Crie um arquivo de teste chamado `hello.js` usando este código de exemplo na pasta `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Agora execute `node hello.js` no prompt de comando para rodá-lo.

### **Mac**

1. Instale o Node.js (https://nodejs.org/en/download/).
1. Instale o JDK8 para Mac e configure a variável de ambiente `JAVA_HOME`.
1. Modifique a seção JVMCapabilities em `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` com privilégio de superusuário. `jdk1.8.x_xxx.jdk` depende da sua versão do jdk. Deixe assim:
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
4. Instale o python 2.x (se ainda não estiver instalado).
5. Instale as Xcode Command Line Tools.
6. Instale a ponte [`java`](https://www.npmjs.com/package/java). Você pode executar os comandos abaixo no terminal:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Baixe Aspose.Slides for Node.js via Java e extraia-o em `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Crie um arquivo de teste chamado `hello.js` usando este código de exemplo na pasta `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Agora execute `node hello.js` no prompt de comando para rodá-lo.

{{% alert color="primary" %}}
Por favor, use o seguinte [artigo](https://docs.aspose.com/slides/pt/nodejs-java/troubleshooting-installation/) se encontrar erros de compilação durante a instalação do Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **Perguntas Frequentes**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim, por padrão, o Aspose.Slides funciona em modo de avaliação, o que adiciona marcas d'água e pode ter outras limitações. Para remover as restrições, você precisa aplicar uma [licença](/slides/pt/nodejs-java/licensing/) válida.