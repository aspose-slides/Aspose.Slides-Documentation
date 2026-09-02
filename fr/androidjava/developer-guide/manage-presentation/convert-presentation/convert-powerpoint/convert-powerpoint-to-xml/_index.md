---
title: Convertir des présentations PowerPoint en XML sur Android
linktitle: PowerPoint vers XML
type: docs
weight: 145
url: /fr/androidjava/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat.Xml
- enregistrer la présentation au format XML
- exporter la présentation en XML
- flux XML
- Android
- Java
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML sur Android avec Aspose.Slides."
---
## **Vue d'ensemble**

Aspose.Slides for Android via Java peut convertir des présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d’une représentation textuelle pour inspecter la structure de la présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés ou intégrer un flux de travail qui consomme du XML au lieu d’un package de présentation.

Utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) avec [SaveFormat.Xml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/#Xml). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` crée un PowerPoint XML Presentation. Il n’extrait pas les parties individuelles Office Open XML stockées à l’intérieur d’un package PPTX. Si vous avez besoin des parties exactes du package PPTX, comme `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, inspectez le package PPTX lui‑même.

{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) puis passez le chemin de sortie et [SaveFormat.Xml](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/#Xml) à [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). La source peut être n’importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L’exemple suivant convertit une présentation PPTX en fichier XML :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge flux de [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, comme un service web, un fournisseur de stockage ou une chaîne de traitement XML. L’exemple suivant écrit le résultat dans un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) et récupère le XML généré sous forme de tableau d’octets :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Passer xmlData au composant suivant du flux de travail.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparer le XML avec les formats de présentation et d’exportation**

Choisissez le format de sortie en fonction de l’utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison du résultat généré et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les anciens flux de travail PowerPoint |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint classique et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Représentation rendue d’une diapositive individuelle | Vignettes, aperçus et ressources d’image |
| HTML ou HTML5 | Sortie de présentation orientée web | Visualisation dans le navigateur et publication web |

Contrairement à PPT et PPTX, la sortie XML est principalement destinée à l’inspection et aux flux de travail orientés données. Contrairement à PDF, TIFF, HTML et aux formats d’image de diapositive, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d’actifs visuels. Le tableau des [formats de fichiers pris en charge](/slides/fr/androidjava/supported-file-formats/) indique que PowerPoint XML Presentation est un format uniquement enregistrement, il ne faut donc pas l’utiliser lorsqu’un flux de travail doit charger le fichier exporté à nouveau dans Aspose.Slides pour une édition continue.

## **FAQ**

**`SaveFormat.Xml` est‑il identique à l’enregistrement d’un fichier PPTX ?**

Non. PPTX est un package contenant plusieurs parties Office Open XML, tandis que `SaveFormat.Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux inscriptible à [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Par exemple, utilisez un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) pour le traitement en mémoire.

**Aspose.Slides peut‑il recharger le fichier XML exporté ?**

Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l’enregistrement, pas pour le chargement. Utilisez PPTX ou un autre format de présentation pris en charge lorsque vous avez besoin d’un aller‑retour d’édition.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d’image ?**

Non. La conversion XML écrit des données structurées de la présentation. Utilisez PDF ou TIFF pour une sortie orientée pages, ou PNG, JPEG et SVG pour des images de diapositives individuelles.