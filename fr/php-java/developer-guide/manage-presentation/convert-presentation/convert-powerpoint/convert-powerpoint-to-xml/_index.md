---
title: Convertir des présentations PowerPoint en XML en PHP
linktitle: PowerPoint en XML
type: docs
weight: 145
url: /fr/php-java/convert-powerpoint-to-xml/
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
- PHP
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en PHP avec Aspose.Slides for PHP via Java."
---
## **Aperçu**

Aspose.Slides for PHP via Java peut convertir les présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d’une représentation textuelle pour inspecter la structure de la présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés ou l’intégrer à un flux de travail qui consomme du XML plutôt qu’un paquet de présentation.

Utilisez la méthode [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) avec la valeur `Xml` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` crée une PowerPoint XML Presentation. Il n’extrait pas les parties individuelles d’Office Open XML stockées dans un paquet PPTX. Si vous avez besoin des parties exactes du paquet PPTX, comme `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, inspectez le paquet PPTX lui‑même.
{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), puis transmettez le chemin de sortie et `SaveFormat::Xml` à [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). La source peut être n’importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L’exemple suivant convertit une présentation PPTX en fichier XML :
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge flux de [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu’un service web, un fournisseur de stockage ou un pipeline de traitement XML. L’exemple suivant écrit le résultat dans un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) et récupère le XML généré sous forme de tableau d’octets :
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Transmettre $xmlBytes au composant suivant du flux de travail.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Un `ByteArrayOutputStream` stocke toutes les données générées en mémoire, il n’est donc pas nécessaire de réinitialiser la position avant d’appeler `toByteArray`.

## **Comparer le XML avec les formats de présentation et d’exportation**

Choisissez le format de sortie en fonction de l’utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une présentation PowerPoint XML | Inspection de la structure, dépannage, comparaison des résultats générés et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les flux de travail PowerPoint plus anciens |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint classique et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d’une diapositive individuelle | Miniatures, aperçus et ressources image |
| HTML ou HTML5 | Sortie de présentation orientée Web | Affichage dans le navigateur et publication web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l’inspection et aux flux de travail axés sur les données. Contrairement aux formats PDF, TIFF, HTML et aux images de diapositives, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d’assets visuels. Le tableau des [formats de fichiers pris en charge](/slides/fr/php-java/supported-file-formats/) indique que PowerPoint XML Presentation est uniquement disponible en sauvegarde, n’utilisez donc pas ce format lorsqu’un flux de travail doit charger le fichier exporté de nouveau dans Aspose.Slides pour poursuivre l’édition.

## **FAQ**

**Le `SaveFormat::Xml` est‑il identique à l’enregistrement d’un fichier PPTX ?**

Non. Le PPTX est un paquet contenant plusieurs parties Office Open XML, tandis que `SaveFormat::Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux inscriptible à [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Par exemple, utilisez un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) pour un traitement en mémoire.

**Aspose.Slides peut‑il recharger le fichier XML exporté ?**

Non. La présentation PowerPoint XML est actuellement prise en charge uniquement pour l’enregistrement et non pour le chargement. Utilisez PPTX ou un autre format de présentation pris en charge lorsqu’un aller‑retour d’édition est nécessaire.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d’image ?**

Non. La conversion XML écrit des données de présentation structurées. Utilisez PDF ou TIFF pour une sortie orientée page, ou PNG, JPEG et SVG pour des images de diapositives individuelles.