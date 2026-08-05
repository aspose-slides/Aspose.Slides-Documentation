---
title: Extraction avancée de texte des présentations en C++
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
keywords:
- extraction de texte
- extraction de texte de la diapositive
- extraction de texte de la présentation
- extraction de texte de PowerPoint
- extraction de texte d'OpenDocument
- extraction de texte de PPT
- extraction de texte de PPTX
- extraction de texte de ODP
- récupérer le texte
- récupérer le texte de la diapositive
- récupérer le texte de la présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour C++. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Vue d'ensemble**

Extraire du texte des présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec du contenu de diapositive. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d’extraire efficacement du texte de divers formats de présentation, y compris PPT, PPTX et ODP, en utilisant Aspose.Slides for C++. Vous apprendrez comment itérer systématiquement à travers les éléments d’une présentation afin de récupérer avec précision le texte dont vous avez besoin.

## **Extraire du texte d’une diapositive**

Aspose.Slides for C++ fournit l’espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/) qui inclut la classe [SlideUtil](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d’une présentation ou d’une diapositive. Pour extraire le texte d’une diapositive d’une présentation, utilisez la méthode [GetAllTextBoxes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/getalltextboxes/). Cette méthode accepte un objet de type [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/) en paramètre. Lors de son exécution, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d’objets de type [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), en préservant toute la mise en forme du texte.

L'extrait de code suivant extrait tout le texte de la première diapositive de la présentation :

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extraire du texte d’une présentation**

Pour analyser le texte de l’ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/getalltextframes/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/). Elle accepte deux paramètres :

1. Tout d’abord, un objet [IPresentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/) représentant une présentation PowerPoint ou OpenDocument dont le texte sera extrait.  
2. Ensuite, une valeur `Boolean` indiquant si les diapos maîtres doivent être incluses lors de l’analyse du texte de la présentation.

La méthode renvoie un tableau d’objets de type [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), incluant les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les détails de mise en forme d’une présentation, y compris les diapositives maîtres.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/) propose également des méthodes pour extraire tout le texte des présentations :

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

L’argument d’énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textextractionarrangingmode/) indique le mode d’organisation du résultat d’extraction de texte et peut être défini sur les valeurs suivantes :
- `Unarranged` - Le texte brut sans tenir compte de sa position sur la diapositive.  
- `Arranged` - Le texte est disposé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la vitesse est critique ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Sa méthode `get_SlidesText()` renvoie un tableau d’objets de type [ISlideText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidetext/). Chaque objet représente le texte de la diapositive correspondante. L’objet de type [ISlideText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidetext/) possède les méthodes suivantes :

- `get_Text()` - Le texte contenu dans les formes de la diapositive.  
- `get_MasterText()` - Le texte contenu dans les formes de la diapositive maître associée à cette diapositive.  
- `get_LayoutText()` - Le texte contenu dans les formes de la diapositive modèle associée à cette diapositive.  
- `get_NotesText()` - Le texte contenu dans les formes de la diapositive des notes associée à cette diapositive.  
- `get_CommentsText()` - Le texte des commentaires associés à cette diapositive.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**À quelle vitesse Aspose.Slides traite‑t‑il de grandes présentations lors de l’extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et peut traiter même les [grandes présentations](/slides/fr/cpp/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en masse.

**Aspose.Slides peut‑il extraire du texte des tableaux et des graphiques dans les présentations ?**

Oui. Aspose.Slides peut extraire du texte de nombreux éléments de diapositive, y compris les tableaux et les objets liés aux graphiques, vous permettant ainsi d’accéder et d’analyser le contenu textuel des structures de présentation courantes.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire du texte des présentations ?**

Vous pouvez extraire du texte en utilisant la version d’essai gratuite d’Aspose.Slides, bien qu’elle présente [certaines limitations](/slides/fr/cpp/licensing/), comme le traitement d’un nombre limité de diapositives. Pour une utilisation sans restriction et pour gérer des présentations plus volumineuses, l’acquisition d’une licence complète est recommandée.