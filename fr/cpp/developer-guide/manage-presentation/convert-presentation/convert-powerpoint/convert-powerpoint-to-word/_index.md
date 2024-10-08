---
title: Convertir PowerPoint en Word
type: docs
weight: 110
url: /fr/cpp/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Word, DOCX, DOC, PPTX à DOCX, PPT à DOC, PPTX à DOC, PPT à DOCX, C++, Aspose.Slides"
description: "Convertir une présentation PowerPoint en Word en C++ "
---

Si vous prévoyez d'utiliser du contenu textuel ou des informations d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word est mieux équipée avec des outils ou des fonctionnalités pour le contenu. 
* En plus des fonctions d'édition dans Word, vous pourriez également bénéficier de fonctionnalités de collaboration, d'impression et de partage améliorées.

{{% alert color="primary" %}} 

Vous pourriez vouloir essayer notre [**Convertisseur en ligne de présentation à Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec du contenu textuel provenant des diapositives.

{{% /alert %}} 

### **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOC), vous avez besoin de [Aspose.Slides pour C++](https://products.aspose.com/slides/cpp/) et de [Aspose.Words pour C++](https://products.aspose.com/words/cpp/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour C++ fournit des fonctions qui permettent d'extraire des textes des présentations. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) est une API avancée de traitement de documents qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers et effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word**

Utilisez ce morceau de code pour convertir PowerPoint en Word :

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // génère et insère l'image de la diapositive
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // insère les textes de la diapositive
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