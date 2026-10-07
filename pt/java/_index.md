---
title: Aspose.Slides para Java
second_title: Aspose.Slides para Java
type: docs
weight: 20
url: /pt/java/
keywords:
- documentação
- processamento de apresentação
- conversão de apresentação
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides for Java, crie sua primeira apresentação e encontre os guias para tarefas comuns, implantação e a referência da API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java é uma biblioteca de classes para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações Java, sem o Microsoft PowerPoint.

Ele carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes com macros e de modelo, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>COMECAR</p>
<ul>
<li><a href="/slides/pt/java/installation/">Instalação</a></li>
<li><a href="/slides/pt/java/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/java/system-requirements/">Requisitos do sistema</a></li>
<li><a href="/slides/pt/java/getting-started/">Guia de introdução</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/java/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/java/features-overview/">Visão geral dos recursos</a></li>
<li><a href="/slides/pt/java/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/java/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construir com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/java/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/java/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/java/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/java/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/java/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO</p>
<ul>
<li><a href="/slides/pt/java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/java/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/java/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/java/presentation-design/">Design de slide</a></li>
<li><a href="/slides/pt/java/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/java/examples/">Exemplos por elemento de slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Exemplos no GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Implantar &amp; Suporte</b></p>
<hr>
<p>IMPLANTAÇÃO</p>
<ul>
<li><a href="/slides/pt/java/system-requirements/#linux">Pré-requisitos Linux</a></li>
<li><a href="/slides/pt/java/how-to-run-aspose-slides-in-docker/">Executar no Docker</a></li>
<li><a href="/slides/pt/java/deploy-fonts/">Fontes</a></li>
<li><a href="/slides/pt/java/security/">Segurança</a></li>
</ul>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Notas de versão</a></li>
<li><a href="/slides/pt/java/known-issues/">Problemas conhecidos</a></li>
<li><a href="/slides/pt/java/api-limitations/">Limitações de metadados de saída</a></li>
<li><a href="https://products.aspose.com/slides/java/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Sua primeira apresentação**

Aspose.Slides for Java é publicado no repositório Maven próprio da Aspose, não no Maven Central. Crie uma pasta para um projeto Maven e salve este *pom.xml* nela. Ele declara o repositório, adiciona a biblioteca e especifica a classe a ser executada:

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

Salve este código como *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Crie uma apresentação. Ela já contém um slide vazio.
        Presentation presentation = new Presentation();
        try {
            // Obtenha o primeiro slide.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Adicione uma forma de nuvem e coloque texto nela.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Salve a apresentação como um arquivo PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Em seguida, com JDK 11 ou superior e Apache Maven instalados, execute este comando na pasta do projeto:

```bash
mvn compile exec:java
```

O programa salva *new_presentation.pptx* na pasta do projeto, com um slide contendo uma forma de nuvem com texto. No Linux, fontconfig e ao menos uma fonte devem estar instalados; veja [Installation](/slides/pt/java/installation/#linux). Sem uma licença, o arquivo salvo contém uma marca d'água de avaliação — veja [Licensing](/slides/pt/java/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Create Presentations](/slides/pt/java/create-presentation/).