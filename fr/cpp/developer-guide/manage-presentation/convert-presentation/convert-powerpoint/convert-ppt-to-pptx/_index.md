---
title: Convertir PPT en PPTX en C++
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/cpp/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT vers PPTX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertir les fichiers PPT hérité en PPTX en C++ avec Aspose.Slides. Inclut des exemples C++ pour la conversion d’un seul fichier et en lot, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for C++ peut charger un fichier PPT et l’enregistrer en PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) , puis appelez [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) . Libérez la présentation lorsqu’elle n’est plus nécessaire afin de libérer ses ressources.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L’extension du fichier ne sélectionne pas le format de sortie à elle seule ; c’est l’argument [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) qui le fait. Gardez les chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L’exemple suivant convertit chaque fichier `.ppt` d’un répertoire. Chaque fichier est traité indépendamment, de sorte qu’une conversion échouée n’arrête pas le reste du lot.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Pour les charges de travail en production, consignez l’exception complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms des fichiers échoués dans une file d’attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous provoquer un échec de conversion. Voir [Password-Protected Presentations](/cpp/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

En général, la conversion préserve les diapositives, les maîtres, les mises en page, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même façon. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias intégrés, des polices rares ou des macros VBA. Un fichier PPTX ordinaire n’est pas un format activé pour les macros, donc utilisez un flux de travail adapté aux macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré programmatique­ment et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et son comportement en mode diaporama dans le visualiseur prévu. Ne considérez pas qu’un appel réussi à [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) prouve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le binaire PPT hérité. Conservez le PPT original comme copie d’archivage ou de retour en arrière jusqu’à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie à la place, utilisez les conseils spécifiques au format dans [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités PowerPoint modifiables.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [online PPT to PPTX converter](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx) . Pour des conversions répétables, un traitement par lot ou une gestion des erreurs au niveau de l’application, utilisez l’API C++.

## **Articles associés**

- [Enregistrer des présentations en C++](/cpp/save-presentation/)
- [Formats de fichiers pris en charge](/cpp/supported-file-formats/)
- [Ouvrir des présentations en C++](/cpp/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for C++ charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT‑vers‑PPTX préservera‑t‑elle tout le contenu exactement ?**

Elle préserve le contenu de présentation commun, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Passez en revue le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis‑je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l’échec de l’opération de chargement.

**Dois‑je supprimer le fichier PPT après la conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et flux de travail qui vous importent. Cela fournit une copie de secours si une fonctionnalité héritée se convertit différemment.