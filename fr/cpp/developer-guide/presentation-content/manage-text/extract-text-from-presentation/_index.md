---
title: Extraction avancée de texte à partir de présentations en C++
linktitle: Extraire du texte
type: docs
weight: 90
url: /fr/cpp/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte de ODP
- récupérer du texte
- récupérer du texte d'une diapositive
- récupérer du texte d'une présentation
- récupérer du texte de PowerPoint
- récupérer du texte d'OpenDocument
- récupérer du texte de PPT
- récupérer du texte de PPTX
- récupérer du texte de ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Vue d'ensemble**

Extraire du texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec du contenu de diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article propose un guide complet sur la façon d'extraire efficacement du texte de différents formats de présentation, notamment PPT, PPTX et ODP, en utilisant Aspose.Slides for C++. Vous apprendrez à parcourir systématiquement les éléments d'une présentation afin de récupérer précisément le contenu texte dont vous avez besoin.

## **Extraire du texte d'une diapositive**

Aspose.Slides for C++ fournit l'espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/) qui comprend la classe [SlideUtil](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire du texte d'une diapositive d'une présentation, utilisez la méthode [GetAllTextBoxes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/getalltextboxes/). Cette méthode accepte un objet du type [IBaseSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/) en paramètre. Lors de son exécution, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d'objets du type [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), en conservant tout formatage du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :

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

## **Extraire du texte d'une présentation**

Pour parcourir le texte de la présentation complète, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/getalltextframes/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/). Elle accepte deux paramètres :

1. Tout d'abord, un objet [IPresentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.  
2. Ensuite, une valeur `Boolean` indiquant si les diapositives maîtres doivent être incluses lors du balayage du texte de la présentation.

La méthode renvoie un tableau d'objets du type [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/), incluant les informations de formatage du texte. Le code ci‑dessous parcourt le texte et les détails de formatage d'une présentation, y compris les diapositives maîtres.

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

L'argument d'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction de texte et peut être défini sur les valeurs suivantes :
- `Unarranged` – Le texte brut sans tenir compte de sa position sur la diapositive.  
- `Arranged` – Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la vitesse est critique ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Sa méthode `get_SlidesText()` renvoie un tableau d'objets du type [ISlideText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidetext/). Chaque objet représente le texte de la diapositive correspondante. L'objet du type [ISlideText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidetext/) possède les méthodes suivantes :

- `get_Text()` – Le texte présent dans les formes de la diapositive.  
- `get_MasterText()` – Le texte présent dans les formes de la diapositive maîtresse associée à cette diapositive.  
- `get_LayoutText()` – Le texte présent dans les formes de la diapositive de disposition associée à cette diapositive.  
- `get_NotesText()` – Le texte présent dans les formes de la diapositive de notes associée à cette diapositive.  
- `get_CommentsText()` – Le texte présent dans les commentaires associés à cette diapositive.

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

**Quelle est la rapidité d'Aspose.Slides pour traiter de grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et peut traiter même les [présentations volumineuses](/slides/fr/cpp/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en lot.

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques au sein des présentations ?**

Oui. Aspose.Slides peut extraire le texte de nombreux éléments de diapositives, y compris les tableaux et les objets liés aux graphiques, ce qui vous permet d'accéder et d'analyser le contenu textuel dans les structures de présentation courantes.

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte [certaines limitations](/slides/fr/cpp/licensing/), comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour traiter des présentations plus volumineuses, l'achat d'une licence complète est recommandé.