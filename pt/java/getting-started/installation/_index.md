---
title: Instalação
type: docs
weight: 70
url: /pt/java/installation/
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
- Java
- Aspose.Slides
description: "Instale o Aspose.Slides for Java do repositório Maven da Aspose ou como um arquivo JAR, configure os pré-requisitos do Linux e verifique a instalação com um primeiro programa."
---
## **Visão geral**

Este artigo explica como adicionar o Aspose.Slides for Java a um projeto. O Aspose.Slides for Java é publicado no repositório Maven próprio da Aspose, não no Maven Central, portanto um projeto Maven precisa declarar esse repositório. Você também pode baixar o arquivo JAR e colocá‑lo no classpath manualmente. Ambas as abordagens terminam com um pequeno programa que confirma que a biblioteca funciona.

O Aspose.Slides for Java não requer o Microsoft PowerPoint. Ele gera programaticamente os arquivos de apresentação necessários. Contudo, para visualizar as apresentações geradas, pode ser necessário o Microsoft PowerPoint ou outro visualizador de apresentações.

## **Pré-requisitos**

- Um Java Development Kit (JDK). O projeto e os comandos deste artigo requerem JDK 11 ou superior. No JDK 11, o programa que verifica a instalação exibe um aviso que começa com "WARNING: An illegal reflective access operation has occurred"; ele não afeta o resultado e pode ser ignorado.
- [Apache Maven](https://maven.apache.org/install.html), se você usar a rota Maven.
- No Linux, a biblioteca fontconfig e ao menos uma fonte instalada. Veja [Linux](#linux).

## **Instalar a partir do repositório Maven**

A Aspose hospeda suas bibliotecas Java em seu próprio [repositório Maven](https://releases.aspose.com/java/repo/com/aspose/). Para usar o [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) em um projeto Maven, adicione duas entradas ao seu *pom.xml*.

1. **Declarar o repositório Maven da Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Adicionar a dependência Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

O classificador `jdk16` é obrigatório: ele seleciona a compilação Java SE da biblioteca. Substitua `26.9` pela versão mais recente listada no [repositório](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). O repositório publica um arquivo de soma de verificação SHA‑1 ao lado de cada JAR, que o Maven verifica ao baixar a biblioteca.

### **Verificar a instalação**

Para testar a configuração com um novo projeto:

1. Crie uma pasta para o projeto e salve este *pom.xml* nela:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Além do repositório e da dependência, este *pom.xml* define a versão Java para compilação, nomeia a classe que `mvn exec:java` executa e fixa o plugin de compilação, pois o plugin mais antigo que algumas instalações Maven usam por padrão ignora a configuração `maven.compiler.release`.

2. Salve o primeiro exemplo em [Create Presentations](/slides/pt/java/create-presentation/) como *src/main/java/HelloSlides.java*.

3. Na pasta do projeto, execute:

   ```bash
   mvn compile exec:java
   ```

O Maven baixa o Aspose.Slides for Java, compila o programa e o executa. O programa salva *new_presentation.pptx* na pasta do projeto.

## **Usar o arquivo JAR sem Maven**

1. Baixe *aspose-slides-26.9-jdk16.jar* da [pasta de versão](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) no repositório. Para outra versão, abra sua pasta no [repositório](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) e baixe o arquivo que termina em *-jdk16.jar*.
2. Salve o primeiro exemplo em [Create Presentations](/slides/pt/java/create-presentation/) como *HelloSlides.java* na mesma pasta do arquivo JAR.
3. Nesse diretório, execute:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

O JDK compila e executa o arquivo‑fonte único, e o programa salva *new_presentation.pptx* na pasta. Em sua própria aplicação, adicione o arquivo JAR ao classpath na sua ferramenta de build ou IDE.

## **Linux**

O Aspose.Slides for Java usa o suporte a fontes do Java, que no Linux necessita da biblioteca fontconfig e ao menos uma fonte instalada. Sem elas, a gravação de uma apresentação falha com o erro “Fontconfig head is null, check your fonts or fonts configuration”. Imagens mínimas de servidor e contêiner podem carecer de ambos; a imagem oficial do contêiner Ubuntu, por exemplo, não tem nenhum deles.

No Debian e no Ubuntu, este comando instala um JDK, Maven, fontconfig e as fontes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

As fontes usadas em suas apresentações, ou substitutos adequados, também devem ser instaladas para que o texto seja renderizado corretamente.

## **Perguntas frequentes**

### Como posso verificar se o Aspose.Slides foi integrado corretamente?

Compile seu projeto, instancie um objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) vazio e salve‑o com um novo nome. Se o arquivo for criado sem lançar exceções, a biblioteca foi integrada com sucesso.

### Como posso limitar o consumo de memória ao processar apresentações grandes?

Aumente os limites de memória da JVM apenas o necessário e chame [dispose](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#dispose--) em cada instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) dentro de um bloco `finally` para liberar o cache rapidamente. Isso evita erros de falta de memória e mantém o uso geral de memória previsível durante operações em lote.

### Posso excluir formatos de exportação indesejados para reduzir o tamanho final do JAR?

As versões atuais do Aspose.Slides são distribuídas como uma única biblioteca monolítica, portanto não é possível desativar exportadores específicos, como PDF ou SVG, no momento da compilação.