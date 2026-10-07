---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /fr/java/
keywords:
- documentation
- traitement de présentation
- conversion de présentation
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Commencez ici: installez Aspose.Slides for Java, créez votre première présentation et trouvez les guides pour les tâches courantes, le déploiement et la référence API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java est une bibliothèque de classes permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans les applications Java, sans Microsoft PowerPoint.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/java/installation/">Installation</a></li>
<li><a href="/slides/fr/java/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/java/system-requirements/">Configuration requise</a></li>
<li><a href="/slides/fr/java/getting-started/">Guide de démarrage</a></li>
</ul>
<p>EVALUER</p>
<ul>
<li><a href="/slides/fr/java/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/java/features-overview/">Aperçu des fonctionnalités</a></li>
<li><a href="/slides/fr/java/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/java/licensing/">Licences</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Créer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/java/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/java/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/java/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/java/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/java/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/java/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/java/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/java/presentation-design/">Conception des diapositives</a></li>
<li><a href="/slides/fr/java/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/java/examples/">Exemples par élément de diapositive</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Exemples sur GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Déploiement &amp; Support</b></p>
<hr>
<p>DÉPLOYER</p>
<ul>
<li><a href="/slides/fr/java/system-requirements/#linux">Prérequis Linux</a></li>
<li><a href="/slides/fr/java/how-to-run-aspose-slides-in-docker/">Exécuter dans Docker</a></li>
<li><a href="/slides/fr/java/deploy-fonts/">Polices</a></li>
<li><a href="/slides/fr/java/security/">Sécurité</a></li>
</ul>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/java/known-issues/">Problèmes connus</a></li>
<li><a href="/slides/fr/java/api-limitations/">Limitations des métadonnées de sortie</a></li>
<li><a href="https://products.aspose.com/slides/java/">Page produit</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Assistance payante</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Votre première présentation**

Aspose.Slides for Java est publié dans le référentiel Maven propre à Aspose, et non dans Maven Central. Créez un dossier pour un projet Maven et enregistrez-y ce *pom.xml*. Il déclare le référentiel, ajoute la bibliothèque et indique la classe à exécuter :

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

Enregistrez ce code sous *src/main/java/HelloSlides.java* :

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Créer une présentation. Elle contient déjà une diapositive vide.
        Presentation presentation = new Presentation();
        try {
            // Obtenir la première diapositive.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Ajouter une forme de nuage et y mettre du texte.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Enregistrer la présentation au format PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Ensuite, avec JDK 11 ou supérieur et Apache Maven installés, exécutez cette commande dans le dossier du projet :

```bash
mvn compile exec:java
```

Le programme enregistre *new_presentation.pptx* dans le dossier du projet, avec une diapositive contenant une forme de nuage avec du texte. Sous Linux, fontconfig et au moins une police doivent être installés ; voir [Installation](/slides/fr/java/installation/#linux). Sans licence, le fichier enregistré comporte un filigrane d’évaluation — voir [Licensing](/slides/fr/java/licensing/). Pour d’autres façons de créer et remplir une présentation, voir [Create Presentations](/slides/fr/java/create-presentation/).