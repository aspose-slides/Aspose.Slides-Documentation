---
title: Convertir les présentations PowerPoint en documents Word en C++
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/cpp/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers Word
- présentation vers Word
- diapositive vers Word
- PPT vers Word
- PPTX vers Word
- PowerPoint vers DOCX
- présentation vers DOCX
- diapositive vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- PowerPoint vers DOC
- présentation vers DOC
- diapositive vers DOC
- PPT vers DOC
- PPTX vers DOC
- enregistrer PPT en DOCX
- enregistrer PPTX en DOCX
- exporter PPT en DOCX
- exporter PPTX en DOCX
- C++
- Aspose.Slides
description: "Convertir les diapositives PowerPoint PPT et PPTX en documents Word modifiables en C++ en utilisant Aspose.Slides avec une mise en page, des images et une mise en forme précises conservées."
---

Si vous prevoyez d'utiliser le contenu textuel ou les informations d'une presentation (PPT ou PPTX) de nouvelles manieres, vous pourriez tirer parti de la conversion de la presentation en Word (DOC ou DOCX). 

* Compare a Microsoft PowerPoint, l'application Microsoft Word est davantage equipee d'outils ou de functionalites pour le contenu. 
* En plus des fonctions d'edition dans Word, vous pouvez egalement profiter de functionalites améliorees de collaboration, d'impression et de partage. 

{{% alert color="primary" %}} 

Vous pouvez essayer notre [**convertisseur en ligne de presentation vers Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec le contenu textuel des diapositives. 

{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOCX), vous avez besoin a la fois de [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) et de [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour C++ fournit des fonctions qui vous permettent d'extraire du texte des presentations. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) est une API avancee de traitement de documents qui permet aux applications de generer, modifier, convertir, rendre, imprimer des fichiers et d'effectuer d'autres taches avec des documents sans recourir a Microsoft Word.

## **Convertir une presentation PowerPoint en document Word**

Utilisez cet extrait de code pour convertir le PowerPoint en Word :
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // génère et insère l'image de la diapositive
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // insère le texte de la diapositive
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```


## **FAQ**

**Quels composants doivent etre installs pour convertir des presentations PowerPoint et OpenDocument en documents Word ?**

Vous devez simplement ajouter les packages respectifs pour [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) et [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) a votre projet. Les deux bibliotheques fonctionnent comme des API autonomes, et il n'est pas necessaire d'installer Microsoft Office.

**Tous les formats de presentation PowerPoint et OpenDocument sont-ils pris en charge ?**

Aspose.Slides [prend en charge tous les formats de presentation](/slides/fr/cpp/supported-file-formats/), y compris PPT, PPTX, ODP et d'autres types de fichiers courants. Cela garantit que vous pouvez travailler avec des presentations creees dans differentes versions de Microsoft PowerPoint.