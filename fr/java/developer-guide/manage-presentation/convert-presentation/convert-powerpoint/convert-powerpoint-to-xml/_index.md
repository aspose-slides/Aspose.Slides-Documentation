---
title: Convertir les présentations PowerPoint en XML en Java
linktitle: PowerPoint vers XML
type: docs
weight: 145
url: /fr/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en Java avec Aspose.Slides for Java."
---
## **Aperçu**

Aspose.Slides for Java peut convertir des présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsqu'il est nécessaire de disposer d'une représentation textuelle pour inspecter la structure de la présentation, résoudre les problèmes des documents générés, comparer les résultats dans des tests automatisés ou intégrer un flux de travail qui consomme du XML plutôt qu'un paquet de présentation.

Utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) avec la valeur `Xml` de la classe [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/) . Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crée une présentation PowerPoint XML. Il n'extrait pas les parties individuelles Office Open XML stockées à l'intérieur d'un paquet PPTX. Si vous avez besoin des parties exactes du paquet PPTX, comme `ppt/presentation.xml` ou des fichiers XML de diapositives individuels, examinez le paquet PPTX lui‑même.
{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) , puis transmettez le chemin de sortie et `SaveFormat.Xml` à [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-). La source peut être n'importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L'exemple suivant convertit une présentation PPTX en fichier XML :
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

## **Écrire la sortie XML vers un flux**

Utilisez la surcharge de flux de [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu'un service Web, un fournisseur de stockage ou un pipeline de traitement XML. L'exemple suivant écrit le résultat dans un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) et récupère le XML résultant sous forme de tableau d'octets :
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Passez xmlData au composant suivant du flux de travail.
} finally {
    presentation.dispose();
}
```

## **Comparer le XML avec les formats de présentation et d'exportation**

Choisissez le format de sortie en fonction de l'utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une présentation PowerPoint XML | Inspection de la structure, dépannage, comparaison de la sortie générée et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les flux de travail PowerPoint plus anciens |
| PPTX (`.pptx`) | Un paquet Office Open XML contenant plusieurs parties | Édition PowerPoint classique et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d'une diapositive individuelle | Vignettes, aperçus et ressources image |
| HTML ou HTML5 | Sortie de présentation orientée Web | Visualisation dans le navigateur et publication Web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l'inspection et aux flux de travail orientés données. Contrairement aux formats PDF, TIFF, HTML et aux formats d'image de diapositives, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d'éléments visuels. Le tableau [formats de fichiers pris en charge](/slides/fr/java/supported-file-formats/) répertorie tous les formats qu'Aspose.Slides peut charger, importer, enregistrer ou rendre.

## **FAQ**

**`SaveFormat.Xml` est‑il identique à l'enregistrement d'un fichier PPTX ?**  

Non. PPTX est un paquet contenant plusieurs parties Office Open XML, tandis que `SaveFormat.Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**  

Oui. Transmettez un flux accessible en écriture à [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Par exemple, utilisez un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) pour le traitement en mémoire.

**Aspose.Slides peut‑il charger à nouveau le fichier XML exporté ?**  

Oui. Passez le fichier XML ou un flux au constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) . [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--) renvoie alors `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) indique `LoadFormat.Unknown` pour ce format, il ne faut donc pas l’utiliser pour déterminer si un fichier XML peut être ouvert.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d'image ?**  

Non. La conversion XML écrit des données de présentation structurées. Utilisez PDF ou TIFF pour une sortie orientée pages, ou PNG, JPEG et SVG pour des images de diapositives individuelles.