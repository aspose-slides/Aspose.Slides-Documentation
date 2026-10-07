---
title: Aspose.Slides pour JasperReports
second_title: Aspose.Slides pour JasperReports
type: docs
weight: 70
url: /fr/jasperreports/
keywords:
- documentation
- JasperReports
- JasperReports Server
- exportation de rapport
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides for JasperReports, exportez un premier rapport vers PowerPoint, et retrouvez les guides d'exportation, d'intégration avec JasperReports Server et de support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports ajoute des exportateurs PowerPoint à JasperReports Library et JasperReports Server, de sorte que les applications Java et les serveurs de rapports puissent enregistrer des rapports remplis sous forme de présentations sans Microsoft PowerPoint.

Il exporte un rapport rempli au format PPT et PPTX, une diapositive par page de rapport, ainsi qu'au format PDF et HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/jasperreports/installing-aspose-slides-for-jasperreports/">Installation</a></li>
<li><a href="/slides/fr/jasperreports/product-overview/">Aperçu du produit</a></li>
<li><a href="/slides/fr/jasperreports/system-requirements/">Exigences système</a></li>
<li><a href="/slides/fr/jasperreports/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/jasperreports/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/jasperreports/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/jasperreports/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construire avec Slides</b></p>
<hr>
<p>EXPORT</p>
<ul>
<li><a href="/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/">Exporter vers PPT, PPTX, PDF et HTML</a></li>
<li><a href="/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mapper les polices</a></li>
<li><a href="/slides/fr/jasperreports/integration-with-jasperserver/">Intégration avec JasperReports Server</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/jasperreports/demos-setup/">Projets de démonstration</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Notes de version</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Page du produit</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Téléchargement</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Service d'assistance payant</a></li>
</ul>
</div>
</div>

------

## **Votre première exportation**

Ces étapes compilent un rapport d'une ligne, le remplissent et l'exportent au format PPTX avec JasperReports 6.16.0 depuis Maven Central. Vous avez besoin du JDK 11 ou ultérieur et d'Apache Maven.

1. Téléchargez le ZIP depuis la [page de téléchargement](https://releases.aspose.com/slides/jasperreport/) et décompressez-le. Son dossier *lib* contient un sous‑dossier par plage de versions de JasperReports, chacun contenant le jar correspondant. Pour JasperReports 6.16.0, copiez *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* dans un dossier de projet vide.

2. Le jar est fourni dans le ZIP plutôt que dans un dépôt Maven, il faut donc l'installer dans votre dépôt Maven local. Exécutez cette commande dans le dossier du projet :

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Enregistrez ce *pom.xml* dans le dossier du projet. Il ajoute JasperReports 6.16.0 et le jar que vous avez installé, et indique la classe à exécuter. JasperReports 6.16.0 déclare une version modifiée d'iText qui n'est pas disponible sur Maven Central, ainsi le fichier l'exclut ; les exportateurs Aspose n'en ont pas besoin.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. Enregistrez cette conception de rapport sous le nom *hello.jrxml* dans le dossier du projet. Elle affiche une ligne de texte dans la bande de titre :

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Enregistrez ce code sous *src/main/java/HelloExport.java*. Il compile la conception, la remplit avec un enregistrement vide et exporte le résultat avec `ASPptxExporter` :

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Compilez la conception du rapport et remplissez-le avec un enregistrement vide.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportez le rapport rempli au format PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Exécutez cette commande dans le dossier du projet :

```bash
mvn compile exec:java
```

Le programme enregistre *hello.pptx* dans le dossier du projet, avec une diapositive contenant le texte du rapport. Le compilateur indique que le code utilise une API obsolète : les exportateurs prennent leurs entrées et sorties via `JRExporterParameter`, et n'acceptent pas la configuration plus récente `setExporterInput` et `setExporterOutput`. Sous Linux, fontconfig et au moins une police doivent être installés, sinon le remplissage du rapport échoue. Sans licence, chaque diapositive porte un filigrane d'évaluation au centre — voir [Licence](/slides/fr/jasperreports/licensing/). Pour exporter vers PPT, PDF ou HTML, voir [Exportation PPT, PPTX, PDF et HTML](/slides/fr/jasperreports/ppt-pptx-pdf-and-html-export/).