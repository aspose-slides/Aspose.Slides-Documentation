---
title: Aspose.Slides para Java
second_title: Aspose.Slides para Java
type: docs
weight: 20
url: /es/java/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Empieza aquí: instala Aspose.Slides for Java, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de la API y el soporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java es una biblioteca de clases para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones Java, sin Microsoft PowerPoint.

Carga y guarda PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/java/installation/">Instalación</a></li>
<li><a href="/slides/es/java/create-presentation/">Crear su primera presentación</a></li>
<li><a href="/slides/es/java/getting-started/">Guía de inicio rápido</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/java/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/java/evaluate-aspose-slides/">Limitaciones de la evaluación</a></li>
<li><a href="/slides/es/java/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construir con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/java/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/java/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/java/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/java/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/java/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/java/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/java/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/java/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/java/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/java/examples/">Ejemplos por elemento de diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Ejemplos en GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia y Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/java/known-issues/">Problemas conocidos</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Aspose.Slides for Java se publica en el propio repositorio Maven de Aspose, no en Maven Central. Cree una carpeta para un proyecto Maven y guarde este *pom.xml* en ella. Declara el repositorio, añade la biblioteca y especifica la clase a ejecutar:

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

Guarde este código como *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Crear una presentación. Ya contiene una diapositiva vacía.
        Presentation presentation = new Presentation();
        try {
            // Obtener la primera diapositiva.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Añadir una forma de nube y poner texto en ella.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Guardar la presentación como un archivo PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Luego, con JDK 11 o posterior y Apache Maven instalados, ejecute este comando en la carpeta del proyecto:

```bash
mvn compile exec:java
```

El programa guarda *new_presentation.pptx* en la carpeta del proyecto, con una diapositiva que contiene una forma de nube con texto. En Linux, se debe instalar fontconfig y al menos una fuente; consulte la [Instalación](/slides/es/java/installation/#linux). Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — vea la [Licenciamiento](/slides/es/java/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear Presentaciones](/slides/es/java/create-presentation/).