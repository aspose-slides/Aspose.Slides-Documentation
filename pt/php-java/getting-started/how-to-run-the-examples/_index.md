---
title: Como Executar os Exemplos
type: docs
weight: 140
url: /pt/php-java/how-to-run-the-examples/
keywords:
- exemplos
- requisitos de software
- GitHub
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Execute exemplos do Aspose.Slides para PHP via Java rapidamente: clone o repositório, restaure os pacotes e, em seguida, compile e teste recursos para PPT, PPTX e ODP."
---
## **Baixar do GitHub**
Todos os exemplos do Aspose.Slides para PHP via Java estão hospedados no [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Você pode clonar o repositório usando seu cliente Github favorito ou baixar o arquivo ZIP [aqui](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extraia o conteúdo do arquivo ZIP para qualquer pasta no seu computador. Todos os exemplos estão localizados na pasta **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importar Exemplos no IDE**
O projeto usa o sistema de build Maven. Qualquer IDE moderna pode abrir ou importar o projeto e suas dependências facilmente. A seguir mostramos como usar IDEs populares para compilar e executar os exemplos.

### **IntelliJ IDEA**
Clique no menu **File** e escolha **Open**. Navegue até a pasta do projeto e selecione o arquivo **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Ele abrirá o projeto e baixará as dependências automaticamente. Na aba Project, navegue pelos exemplos na pasta **src/main/java**. Para executar um exemplo, basta clicar com o botão direito no arquivo e escolher "Run ..", o exemplo será executado e a saída será exibida na janela de console integrada.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Clique no menu **File** e escolha **Import**. Selecione **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navegue até a pasta que você clonou ou baixou do GitHub e selecione o arquivo **pom.xml**. Ele abrirá o projeto e baixará as dependências automaticamente. Na aba Package Explorer, navegue pelos exemplos na pasta **src/main/java**. Para executar um exemplo, basta clicar com o botão direito no arquivo e escolher **Run As** – **Java Application**, o exemplo será executado e a saída será exibida na janela de console integrada.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Clique no menu **File** e escolha **Open Project**. Navegue até a pasta que você clonou ou baixou do GitHub. O ícone da pasta **Examples** indicará que se trata de um projeto Maven. Selecione **Examples** e abra-o.

![todo:image_alt_text](netbeans_openproject.png)

Ele abrirá o projeto e baixará as dependências automaticamente. Na aba Projects, navegue pelos exemplos em **source packages**. Para executar um exemplo, basta clicar com o botão direito no arquivo e escolher **Run File**, o exemplo será executado e a saída será exibida na janela de console integrada.

![todo:image_alt_text](netbeans_run_example.png)

## **Adicionar a Biblioteca Aspose.Slides ao Repositório Local do Maven**
Ao importar o projeto **Aspose.Slides Examples** para a IDE, o Maven baixa automaticamente o JAR aspose.slides do [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Caso você não tenha acesso à internet, pode adicionar o JAR manualmente ao seu repositório local.

### **mvn install**
Baixe o [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), extraia-o e copie o arquivo aspose.slides‑version.jar para outro local, por exemplo, a unidade C. Execute o comando a seguir:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Agora, o jar **aspose.slides** foi copiado para o seu repositório local do Maven.

### **pom.xml**
Após a instalação, basta declarar a coordenada **aspose.slides** no pom.xml. Adicione o repositório a seguir na aba repositories e a dependência na aba dependencies.

```xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php
```

### **Concluído**
Compile-o, agora o jar **aspose.slides** pode ser obtido do seu repositório local do Maven.

## **Contribuir**
Se você quiser adicionar ou melhorar um exemplo, incentivamos que contribua com o projeto. Todos os exemplos e projetos de demonstração neste repositório são de código aberto e podem ser usados livremente em suas próprias aplicações.

Para contribuir, você pode fazer fork do repositório, editar o código‑fonte e enviar um Pull Request. Revisaremos as alterações e as incluiremos no repositório se forem úteis.