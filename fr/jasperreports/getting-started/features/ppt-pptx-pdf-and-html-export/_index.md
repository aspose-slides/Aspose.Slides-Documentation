---
title: Exportation PPT, PPTX, PDF et HTML
type: docs
weight: 20
url: /fr/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Choisissez l'exportateur Aspose.Slides for JasperReports pour la sortie PPT, PPTX, PDF ou HTML, exportez un rapport rempli avec celui-ci, et mappez les polices du rapport aux polices de la présentation."
---
## **Exportateurs**

Aspose.Slides for JasperReports ajoute quatre exportateurs à JasperReports. Chacun prend un rapport rempli (`JasperPrint`) et exporte chaque page du rapport : comme une diapositive en PPT et PPTX, comme une page en PDF, et comme une image SVG dans un seul fichier HTML.

| Format de sortie | Classe d'exportateur |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Les classes se trouvent dans le package `com.aspose.slides.jasperreports` du jar de la bibliothèque, et elles n’utilisent pas Microsoft PowerPoint. Passez le rapport et le fichier de sortie à un exportateur avec `setParameter` et `JRExporterParameter`, que JasperReports marque comme obsolète : les exportateurs n’acceptent pas la configuration plus récente `setExporterInput` et `setExporterOutput`.

## **Exporter un rapport vers les quatre formats**

Le programme ci‑dessous s’appuie sur le projet de [Votre première exportation](/slides/fr/jasperreports/#your-first-export). Il compile et remplit *hello.jrxml* une fois, puis passe le rapport rempli à chaque exportateur à tour de rôle. Enregistrez‑le sous *src/main/java/ExportAllFormats.java* dans ce projet :

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Compilez et remplissez le rapport une fois.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportez le même rapport rempli avec chaque exportateur.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Exécutez‑le depuis le répertoire du projet :

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Le programme enregistre *hello.ppt*, *hello.pptx*, *hello.pdf* et *hello.html* dans le répertoire du projet. La méthode d’assistance prend `ASAbstractExporter`, la classe de base des quatre exportateurs. Sans licence, chaque fichier de sortie porte le filigrane d’évaluation — voir [Évaluer Aspose.Slides](/slides/fr/jasperreports/evaluate-aspose-slides/).

![Un rapport exporté vers une présentation sans licence](ppt-pptx-pdf-and-html-export_1.png)

## **Mapper les polices**

Les exportateurs PPT et PPTX écrivent les noms de police du modèle de rapport dans la présentation sans les modifier. Lorsqu’un élément texte n’a aucune police spécifiée, JasperReports utilise la police par défaut, `SansSerif`, qui est un nom de police logique Java plutôt qu’une police installée. Pour remplacer ces noms, passez une carte des noms de police du rapport vers les noms de police que vous souhaitez dans la présentation dans le paramètre `ASExporterParameters.PPT_FONT_MAP`. Les clés doivent correspondre exactement aux noms de police du rapport, y compris la casse. Chaque valeur doit être une police que Java trouve sur la machine qui exécute l’exportation ; les exportateurs ignorent une entrée dont la police n’est pas trouvée par Java.

Enregistrez ce programme sous *src/main/java/MapFonts.java* dans le même projet. Il exporte *hello.jrxml* vers PPTX avec `SansSerif` remplacé par Arial :

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Associez le nom de police du rapport au nom de police à écrire dans la présentation.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Exécutez‑le depuis le répertoire du projet :

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Dans le *hello-arial.pptx* enregistré, le texte du rapport utilise Arial au lieu de `SansSerif`. Sur une machine où Java ne trouve pas Arial, comme un système Linux sans cette police, le texte conserve `SansSerif`. Sur JasperReports Server, définissez la même carte via la propriété `fontMap` du bean des paramètres d’exportation — voir [Intégration avec JasperServer](/slides/fr/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).