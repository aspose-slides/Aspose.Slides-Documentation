---
title: Enregistrer des présentations en C++
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/cpp/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la vignette
- progression de l'enregistrement
- C++
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations en C++ avec Aspose.Slides — exportez vers PowerPoint ou OpenDocument tout en conservant les mises en page, les polices et les effets."
---

## **Vue d'ensemble**

[Ouvrir des présentations en C++](/slides/fr/cpp/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une présentation existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides for C++, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer les présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Effectuez du travail ici...

// Enregistrez la présentation dans un fichier.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **Enregistrer les présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Une présentation peut être écrite dans de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Enregistrez la présentation dans le flux.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **Enregistrer les présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/). Utilisez la méthode [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/).
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Enregistrer les présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) et définissez sa propriété `Conformance` lors de l’enregistrement. Si vous définissez `Conformance.Iso29500_2008_Strict`, le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Enregistrez la présentation au format Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 GB (2^32 octets) sur la taille non compressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions de format ZIP64 relèvent ces limites à 2^64.

La méthode [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) vous permet de choisir quand utiliser les extensions de format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- `IfNecessary` utilise les extensions ZIP64 uniquement si la présentation dépasse les limitations ci‑dessus. C’est le mode par défaut.  
- `Never` n’utilise jamais les extensions ZIP64.  
- `Always` utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation au format PPTX avec les extensions ZIP64 activées :
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec `Zip64Mode.Never`, une [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer les présentations sans actualiser la vignette**

La méthode [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) contrôle la génération de la vignette lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `true`, la vignette est actualisée pendant l’enregistrement. C’est le comportement par défaut.  
- Si elle est définie sur `false`, la vignette actuelle est conservée. Si la présentation n’a pas de vignette, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans actualiser sa vignette.
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Cette option permet de réduire le temps requis pour enregistrer une présentation au format PPTX.
{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**

L’interface [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) est utilisée via la méthode `set_ProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/). Assignez une implémentation de [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) avec `set_ProgressCallback` pour recevoir les mises à jour de progression d’enregistrement en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Utilisez la valeur du pourcentage de progression ici.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite de fractionnement PowerPoint](https://products.aspose.app/slides/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées comme nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La fonction « sauvegarde rapide » (sauvegarde incrémentielle) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier cible complet à chaque fois ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sécurisé d’enregistrer la même instance de Presentation depuis plusieurs threads ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) **n’est pas thread‑safe** (/slides/fr/cpp/multithreading/) ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

Les [hyperliens](/slides/fr/cpp/manage-hyperlinks/) sont conservés. Les fichiers liés externement (par ex. les vidéos via des chemins relatifs) ne sont pas copiés automatiquement — assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Entreprise, Date) ?**

Oui. Les [propriétés standard du document](/slides/fr/cpp/presentation-properties/) sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.