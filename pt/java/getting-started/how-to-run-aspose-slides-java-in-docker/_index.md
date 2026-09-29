---
title: Executar Aspose.Slides for Java no Docker
linktitle: Docker
type: docs
weight: 150
url: /pt/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Contêiner Docker
- compilação multi-etapa
- imagem de contêiner
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- fontes
- conversão de PDF
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Compile e execute uma aplicação Aspose.Slides for Java no Docker: um Dockerfile multi-etapa nas imagens oficiais do Maven e Eclipse Temurin, as bibliotecas e fontes Linux que o Aspose.Slides necessita, e como copiar os arquivos gerados para sua máquina."
---
## **Visão Geral**

Este artigo mostra como executar Aspose.Slides for Java em um contêiner Docker. Você cria um pequeno projeto Maven que gera uma apresentação com uma caixa de texto e a converte para PDF, empacota‑a com um Dockerfile de múltiplas etapas nas imagens oficiais do Maven e do Eclipse Temurin, executa‑a e copia os arquivos gerados para sua máquina. O artigo também explica o que o Aspose.Slides precisa em uma imagem Linux além do Java e termina com variantes para Alpine Linux e para imagens que instalam o Java a partir dos pacotes da distribuição.

Você só precisa do Docker na sua máquina. O JDK e o Maven fazem parte da imagem de compilação, portanto você não precisa instalá‑los. Para instalar o Docker, veja [Obter Docker](https://docs.docker.com/get-started/get-docker/).

## **Escolher as Imagens Base**

O Dockerfile neste artigo usa duas imagens oficiais do Docker Hub:

- [maven](https://hub.docker.com/_/maven) com a tag `3.9-eclipse-temurin-21` compila a aplicação. Ela contém Apache Maven 3.9 e o Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) com a tag `21-jre` a executa. Ela contém o runtime Eclipse Temurin Java 21 no Ubuntu, sem o JDK e o Maven.

Aspose.Slides for Java desenha texto com o suporte a fontes do Java, que no Linux necessita das bibliotecas fontconfig e FreeType e de ao menos uma fonte instalada. As imagens Eclipse Temurin já contêm fontconfig, FreeType e as fontes DejaVu, portanto o Dockerfile neste artigo não instala pacotes. Em uma imagem sem nenhuma fonte, salvar a apresentação falha com o erro “Fontconfig head is null, check your fonts or fonts configuration”. Se você compilar em outra imagem base, veja [Use outra imagem base](#use-another-base-image).

## **Criar o Projeto**

Crie uma pasta chamada *hello-slides-docker* e adicione os seguintes arquivos a ela.

*pom.xml* declara o repositório Maven da Aspose e a dependência Aspose.Slides for Java, conforme descrito em [Installation](/slides/pt/java/installation/); Aspose.Slides for Java não está publicado no Maven Central, portanto a entrada do repositório é necessária. O elemento `finalName` nomeia o JAR da aplicação como *hello-slides.jar*, e o [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) copia as dependências da aplicação para *target/lib* quando o Maven a empacota. Defina a versão do Aspose.Slides para a mais recente listada no [repositório](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* cria uma [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/), adiciona um retângulo com texto ao seu primeiro slide e salva a apresentação duas vezes com o método [save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-): como PPTX e como PDF. Ambos os arquivos vão para a pasta *output* sob o diretório de trabalho. O programa então lista as fontes que o Aspose.Slides substitui ao renderizar a apresentação, usando [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), para que você veja se o contêiner possui as fontes usadas pela apresentação.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* impede que a pasta *target* de uma compilação local e a saída de execuções anteriores entrem no contexto de compilação do Docker, de modo que a imagem seja construída apenas a partir dos arquivos fonte.

```text
target/
output/
```

## **Escrever o Dockerfile**

Adicione um arquivo chamado *Dockerfile* à pasta *hello-slides-docker*:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

O arquivo tem duas etapas:

- **A etapa de compilação** inicia a partir da imagem Maven. Ela copia primeiro o *pom.xml* e executa `mvn dependency:go-offline`, que baixa Aspose.Slides for Java e os plugins Maven, de modo que o Docker reutiliza essa camada enquanto o *pom.xml* não mudar. Em seguida copia o código fonte e executa `mvn package`, que compila o programa em *target/hello-slides.jar* e copia o JAR do Aspose.Slides para *target/lib*. A opção `-B` executa o Maven em modo não interativo (batch).
- **A etapa de runtime** inicia a partir da imagem de runtime Java menor e copia somente o JAR da aplicação e a pasta *lib*. Ela cria a pasta *output*, atribui‑a ao usuário `ubuntu`, o usuário não‑root que a imagem baseada em Ubuntu define, e executa a aplicação como esse usuário. O classpath `hello-slides.jar:lib/*` contém a aplicação e todos os JARs em *lib*; o Java expande o `*` por conta própria.

O projeto é compilado para Java 11 (a propriedade `maven.compiler.release`), de modo que a etapa de runtime pode usar uma versão Java mais nova. Por exemplo, para executar a aplicação em Java 25, altere a imagem da etapa de runtime para `eclipse-temurin:25-jre`.

## **Compilar e Executar o Contêiner**

Abra um terminal na pasta *hello-slides-docker*. Compile a imagem e, em seguida, execute um contêiner a partir dela:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

A primeira compilação baixa as imagens base, os plugins Maven e Aspose.Slides for Java, portanto leva alguns minutos; compilações posteriores reutilizam esses artefatos. O contêiner executa a aplicação e encerra. Ele imprime:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

A primeira linha mostra que o texto usa Calibri, a fonte padrão de uma nova apresentação, e que o Calibri não está instalado na imagem, de modo que o Aspose.Slides desenhou o texto com DejaVu Sans. O texto no PDF é real, selecionável, nessa fonte. Sem licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide que salva; veja [Licensing](/slides/pt/java/licensing/).

## **Copiar a Saída para a Sua Máquina**

Os arquivos estão na pasta */app/output* do contêiner interrompido. Copie‑os para uma pasta *output* na sua máquina e, em seguida, remova o contêiner:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Esses dois comandos funcionam da mesma forma no Bash, PowerShell e no Prompt de Comando do Windows.

No Linux, você pode montar uma pasta da sua máquina no contêiner, de modo que a aplicação escreva os arquivos diretamente lá:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

A opção `--user` executa a aplicação com os IDs de usuário e grupo do seu usuário, permitindo que ela escreva na pasta que você criou e que os arquivos pertençam a você. `--rm` remove o contêiner quando ele para.

## **Executar no Alpine Linux**

Eclipse Temurin também está disponível como imagem baseada em Alpine Linux, que é menor. Ela contém fontconfig, FreeType e as fontes DejaVu, de modo que a aplicação não precisa de pacotes adicionais lá também. Para usá‑la, substitua a etapa de runtime no *Dockerfile* (tudo a partir da segunda linha `FROM`) por:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

A imagem Alpine não tem usuário `ubuntu`, portanto esta etapa cria um usuário chamado `app` com `adduser` e executa a aplicação como esse usuário. Compile, execute e copie a saída com os mesmos comandos acima. A aplicação imprime as mesmas duas linhas.

## **Usar Outra Imagem Base**

Se sua imagem instala o Java a partir dos pacotes da distribuição Linux, instale as bibliotecas de fontes do Java e uma fonte junto com ele. No Debian e no Ubuntu, o pacote `openjdk-21-jre-headless` lista fontconfig, FreeType e HarfBuzz apenas como pacotes recomendados, portanto `apt-get install --no-install-recommends` os omite, e a aplicação falha com um `UnsatisfiedLinkError` para `libfontmanager.so`. Esta etapa de runtime instala o Java 21, as bibliotecas e as fontes DejaVu no Debian 13 e cria um usuário não‑root chamado `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

A mesma etapa funciona no Ubuntu 26.04 com `FROM ubuntu:26.04`.

## **FAQ**

**Salvar a apresentação para de funcionar com “Fontconfig head is null, check your fonts or fonts configuration”. O que está faltando?**

Uma fonte. O suporte a fontes do Java não encontrou nenhuma fonte instalada na imagem. Instale um pacote de fontes, por exemplo `fonts-dejavu-core` no Debian e Ubuntu, como em [Use outra imagem base](#use-another-base-image). [Deploy Fonts](/slides/pt/java/deploy-fonts/) lista outros pacotes de fontes.

**A aplicação para com um UnsatisfiedLinkError para libfontmanager.so. O que está faltando?**

Uma biblioteca nativa do suporte a fontes do Java; a mensagem indica o arquivo que não pôde ser carregado, por exemplo `libharfbuzz.so.0`. Isso ocorre quando o Java é instalado a partir dos pacotes da distribuição sem os seus pacotes recomendados. Instale as bibliotecas listadas em [Use outra imagem base](#use-another-base-image).

**Por que o texto no PDF está em uma fonte diferente da do PowerPoint?**

As fontes usadas pela apresentação não estão instaladas na imagem, de modo que o Aspose.Slides desenha o texto com uma fonte substituta. A saída da aplicação nomeia cada fonte substituída. [Deploy Fonts](/slides/pt/java/deploy-fonts/) explica como instalar fontes na imagem ou carregá‑las a partir da pasta da aplicação.

**Quanto de memória a aplicação pode usar no contêiner?**

Por padrão, o Java limita seu heap a um quarto da memória disponível para o contêiner, por exemplo aproximadamente 250 MB ao iniciar o contêiner com `docker run -m 1g`. Para processar apresentações grandes, aumente a parcela com a opção `MaxRAMPercentage`, por exemplo `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. O Java então imprime uma linha “Picked up JAVA_TOOL_OPTIONS” antes da saída da aplicação.

**Preciso de JDK ou Maven na minha máquina?**

Não. A etapa de compilação compila a aplicação dentro da imagem Maven. Você só precisa de JDK e Maven se também quiser compilar e executar a aplicação fora do Docker; veja [Installation](/slides/pt/java/installation/).