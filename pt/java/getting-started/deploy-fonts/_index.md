---
title: Implantar fontes para Aspose.Slides for Java no Linux e em Docker
linktitle: Implantar Fontes
type: docs
weight: 155
url: /pt/java/deploy-fonts/
keywords:
- implantar fontes
- instalar fontes
- fontes no Docker
- fontes no Linux
- fontes ausentes
- substituição de fontes
- fontes principais da Microsoft
- ttf-mscorefonts-installer
- fontes personalizadas
- fonte padrão
- servidor
- container
- conversão PDF
- apresentação
- Java
- Aspose.Slides
description: "Implante fontes para Aspose.Slides for Java em servidores Linux e em containers Docker: verifique quais fontes são substituídas, instale pacotes de fontes no Debian, Ubuntu e Alpine, adicione seus próprios arquivos de fonte e defina uma fonte padrão."
---
## **Visão geral**

Aspose.Slides desenha o texto com as fontes que estão disponíveis para ele ao renderizar uma apresentação, por exemplo ao converter slides para PDF ou para imagens. Um desktop Windows normalmente tem as fontes que as apresentações utilizam. Servidores Linux e containers geralmente têm poucas fontes, de modo que Aspose.Slides desenha o texto com uma fonte substituta. Uma substituta possui formas e larguras de letras diferentes, portanto as linhas podem ser quebradas de forma distinta e o texto pode transbordar sua forma, e os caracteres que a substituta não possui não são desenhados corretamente. Se nenhuma fonte estiver instalada, o suporte a fontes do Java não pode iniciar e Aspose.Slides para com um erro.

Este artigo mostra como verificar quais fontes Aspose.Slides substitui, como instalar fontes no Debian, Ubuntu e Alpine Linux, como adicionar seus próprios arquivos de fonte e como definir a fonte usada quando uma fonte está ausente. Os exemplos são executados em Docker nas imagens oficiais do Eclipse Temurin, como em [Run Aspose.Slides for Java in Docker](/slides/pt/java/how-to-run-aspose-slides-in-docker/). Os comandos de pacote são instruções Dockerfile; em um servidor Linux, execute os mesmos comandos como root.

Para a própria API de fontes, como incorporação de fontes em uma apresentação e regras de fallback e substituição, consulte [PowerPoint Fonts](/slides/pt/java/powerpoint-fonts/).

## **Verificar quais fontes são substituídas**

O projeto Maven a seguir relata as fontes que Aspose.Slides substitui no ambiente atual. Crie uma pasta chamada *font-check* e adicione os arquivos abaixo a ela.

*`pom.xml`* é o mesmo usado em [Run Aspose.Slides for Java in Docker](/slides/pt/java/how-to-run-aspose-slides-in-docker/#create-the-project), com o *artifact ID* e o nome do arquivo JAR alterados para *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*`src/main/java/FontCheck.java`* adiciona uma caixa de texto por nome de fonte a um slide e atribui a fonte com o método [setLatinFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Os nomes das fontes vêm da linha de comando; sem argumentos, o programa verifica Calibri, Arial e Times New Roman. Ele imprime as pastas nas quais Aspose.Slides procura fontes ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#getFontFolders--)), renderiza o slide para *output/fonts.pdf* e imprime as substituições relatadas por [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). As duas etapas opcionais no início, carregar uma pasta *fonts* e ler a variável `DEFAULT_FONT`, são explicadas mais adiante neste artigo.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // As fontes a verificar: os argumentos de linha de comando ou três fontes comuns do Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Carregue os arquivos de fontes da pasta fonts no diretório de trabalho, se houver.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Use a fonte nomeada na variável de ambiente DEFAULT_FONT, se estiver definida, para texto cuja fonte está ausente.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` pode retornar uma pasta mais de uma vez, portanto o programa coleta as pastas em um conjunto antes de imprimi‑las.

*.dockerignore* mantém os resultados de compilação local fora do contexto de build:

```text
target/
output/
```

*Dockerfile* compila o programa com a imagem Maven e o executa na imagem Eclipse Temurin Java, que já contém fontconfig e as fontes DejaVu. [Run Aspose.Slides for Java in Docker](/slides/pt/java/how-to-run-aspose-slides-in-docker/) explica cada instrução.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Compile a imagem e execute a verificação:

```bash
docker build -t font-check .
docker run --rm font-check
```

A imagem contém apenas as fontes DejaVu, portanto as três fontes são substituídas por DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Para verificar as fontes de suas próprias apresentações, passe seus nomes como argumentos, por exemplo `docker run --rm font-check "Segoe UI" Consolas`. Para copiar *output/fonts.pdf* para fora do container, use os comandos em [Copy the Output to Your Machine](/slides/pt/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalar fontes no Debian e Ubuntu**

### **Fontes principais da Microsoft**

O pacote `ttf-mscorefonts-installer` baixa e instala as fontes principais da Microsoft para a web, entre elas Arial, Times New Roman, Courier New, Verdana, Georgia e Trebuchet MS. As fontes são licenciadas sob o contrato de licença de usuário final (EULA) da Microsoft, e o pacote as instala apenas após a aceitação da EULA. Uma compilação Docker não pode responder ao prompt, de modo que o instalador recusa a EULA e não instala fontes, embora `apt-get install` ainda indique sucesso. Aceite a EULA com `debconf-set-selections` **antes** de o pacote ser instalado. Aceitá‑la em uma instrução posterior não ajuda: o pacote já está instalado e o apt não executa o instalador novamente.

Adicione esta instrução à fase de runtime do *Dockerfile*, logo após a linha `FROM`, para que seja executada como root, antes da instrução `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Compile a imagem e execute a verificação novamente com os mesmos dois comandos. Arial e Times New Roman agora estão instalados:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, a fonte padrão de uma apresentação que Aspose.Slides cria, não é uma das fontes principais, portanto ainda é substituída. Veja [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

As imagens Eclipse Temurin baseadas em Ubuntu habilitam `multiverse`, o componente Ubuntu que contém o pacote. No Debian, o pacote está no componente `contrib`, que as imagens Debian não habilitam. Em uma fase de runtime baseada em Debian, como a mostrada em [Use Another Base Image](/slides/pt/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), habilite `contrib` na mesma instrução:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Outros pacotes de fontes**

Debian e Ubuntu também empacotam fontes livremente licenciadas, por exemplo:

| Pacote | Fontes |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif e Mono, com as mesmas métricas de Arial, Times New Roman e Courier New |
| `fonts-crosextra-carlito` | Carlito, com as mesmas métricas de Calibri |
| `fonts-crosextra-caladea` | Caladea, com as mesmas métricas de Cambria |

Instale‑as com `apt-get install` em uma instrução `RUN` da fase de runtime, da mesma forma que as fontes principais da Microsoft. Aspose.Slides for Java não aplica os alias de fontes da configuração de fontes do Linux: com `fonts-liberation` instalado, o texto em Arial ainda é desenhado com a fonte substituta geral, não com Liberation Sans. Para usar uma fonte compatível em métricas no lugar de uma ausente, defina‑a como [fonte padrão](#set-a-default-font-for-missing-fonts) ou adicione uma [regra de substituição de fonte](/slides/pt/java/font-substitution/).

## **Adicionar seus próprios arquivos de fonte**

Fontes que as distribuições não empacotam, como as fontes da sua organização ou outras fontes licenciadas para uso no servidor, podem ser adicionadas como arquivos de fonte. Coloque os arquivos de fonte, por exemplo arquivos *.ttf*, em uma pasta chamada *fonts* dentro da pasta *font-check*. Os exemplos abaixo utilizam os arquivos de Carlito, uma fonte com as mesmas métricas de Calibri, que pode ser baixada em [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalar as fontes em uma pasta de fontes do sistema**

Aspose.Slides lê as fontes nas pastas impressas na linha `Font folders`. Para instalar suas fontes para todas as aplicações na imagem, copie‑as para */usr/local/share/fonts*, a pasta de fontes instaladas localmente. Adicione esta instrução à fase de runtime do *Dockerfile*, após a instrução `RUN` que instala as fontes principais da Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Recompile a imagem e, em seguida, verifique Calibri e Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito não é mais substituída:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Carregar fontes da pasta da aplicação**

Em vez de instalar as fontes em uma pasta de sistema, você pode enviá‑las com a aplicação e carregá‑las com [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). As fontes então ficam disponíveis apenas para Aspose.Slides e são implantadas junto com a aplicação. *FontCheck* faz isso: quando seu diretório de trabalho, */app* no container, contém uma pasta *fonts*, o programa passa essa pasta para `loadExternalFonts` antes de criar a apresentação. [Custom Font](/slides/pt/java/custom-font/) descreve outras formas de fornecer fontes, como carregá‑las da memória.

No *Dockerfile*, remova a instrução `COPY fonts/ /usr/local/share/fonts/` e adicione esta após a instrução que copia a pasta *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Recompile a imagem e execute a verificação com os mesmos dois comandos. A pasta da aplicação agora aparece entre as pastas de fontes, e Carlito ainda não é substituída:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` adiciona fontes às instaladas, porém o suporte a fontes do Java ainda necessita de ao menos uma fonte instalada. Em uma imagem sem nenhuma, `loadExternalFonts` falha com o erro "Fontconfig head is null, check your fonts or fonts configuration".

## **Definir uma fonte padrão para fontes ausentes**

Quando uma fonte está ausente, Aspose.Slides usa uma substituta que ele escolhe automaticamente. Para escolher você mesmo, passe o nome da fonte ao método [setDefaultRegularFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) de [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/) e passe as opções ao construtor de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). *FontCheck* lê o nome da fonte da variável de ambiente `DEFAULT_FONT`. Com Carlito carregada, use‑a para fontes ausentes:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri agora é desenhada com Carlito, cujos caracteres têm as mesmas larguras de Calibri, de modo que o texto mantém suas quebras de linha:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

A fonte padrão substitui toda fonte ausente. Para mapear fontes individuais, por exemplo Arial para Liberation Sans e Calibri para Carlito, use [regras de substituição de fonte](/slides/pt/java/font-substitution/). As regras alteram a saída renderizada, porém `getSubstitutions` não as reflete, portanto verifique as fontes no arquivo de saída. Para texto asiático, também chame [setDefaultAsianFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); veja [Default Font](/slides/pt/java/default-font/).

## **Instalar fontes no Alpine Linux**

A imagem Eclipse Temurin baseada em Alpine também contém as fontes DejaVu; [Run on Alpine Linux](/slides/pt/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) descreve sua fase de runtime. Para instalar as fontes principais da Microsoft nela também, substitua a fase de runtime do Dockerfile *font-check* por esta:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` baixa e instala as mesmas fontes principais da Microsoft que o pacote Debian/Ubuntu, e sua EULA se aplica da mesma forma. `fc-cache` atualiza o cache de fontes do fontconfig. Compile a imagem e execute a verificação com os dois comandos de [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Ele imprime:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Os demais passos desta página funcionam da mesma forma no Alpine: copie a pasta *fonts* para */usr/local/share/fonts* ou para a pasta da aplicação e defina `DEFAULT_FONT` para escolher a fonte padrão. A imagem Alpine não possui a pasta */usr/local/share/fonts*, de modo que ela aparece na linha `Font folders` somente após uma instrução `COPY` criá‑la.

## **FAQ**

**Por que uma apresentação parece diferente quando é convertida em um servidor?**

O servidor não possui as fontes usadas pela apresentação, de modo que Aspose.Slides desenha o texto com uma fonte substituta cujas letras têm larguras diferentes. Execute *FontCheck* com os nomes de fonte da apresentação para ver quais fontes são substituídas, então instale essas fontes ou carregue‑as da pasta da aplicação.

**A compilação instalou ttf‑mscorefonts‑installer, mas Arial ainda é substituída. Por quê?**

A EULA não foi aceita antes da instalação do pacote, portanto o instalador pulou as fontes. Coloque o comando `debconf-set-selections` antes de `apt-get install` na instrução que instala o pacote, como mostrado em [Microsoft Core Fonts](#microsoft-core-fonts), e recompile a imagem.

**O computador que abre o PDF precisa das fontes?**

Não. Nestes exemplos, o PDF contém as fontes usadas para desenhar o texto, portanto ele tem a mesma aparência em qualquer computador. As fontes são necessárias apenas onde Aspose.Slides renderiza a apresentação.