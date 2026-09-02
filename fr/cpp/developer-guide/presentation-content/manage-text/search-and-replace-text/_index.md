---
title: Recherche et remplacement de texte dans les présentations PowerPoint en C++
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/cpp/search-and-replace-text/
keywords:
- recherche de texte
- mise en évidence du texte
- remplacement de texte
- expression régulière
- callback de résultat
- cadre de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Recherchez, mettez en évidence et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ peut rechercher, mettre en évidence et remplacer du texte dans un cadre de texte individuel ou dans l’ensemble d’une présentation. Chaque opération peut également notifier une application à chaque correspondance via un rappel de résultat. Cela rend possible la mise à jour d’une présentation tout en construisant simultanément une trace d’audit contenant le texte correspondant, son contexte, sa position, le cadre de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la censure, les vérifications de terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé **"sample.pptx"**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de [ITextFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/) pour limiter une opération à un seul cadre de texte. Utilisez les méthodes de [IPresentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/) pour traiter tout le texte applicable dans la présentation.

| Opération | Un cadre de texte | Présentation entière |
|---|---|---|
| Mettre en évidence le texte littéral | [ITextFrame::HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/highlighttext/) |
| Mettre en évidence les correspondances d’expression régulière | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/highlightregex/) |
| Remplacer le texte littéral | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/replacetext/) |
| Remplacer les correspondances d’expression régulière | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez [ITextSearchOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/) pour contrôler la correspondance :

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limite les correspondances aux mots complets.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) contrôle si la casse des caractères doit correspondre.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en évidence au niveau de la présentation.

Les opérations d’expression régulière utilisent un `System::Text::RegularExpressions::Regex`, de sorte que les règles de correspondance comme la sensibilité à la casse et les limites de mots sont définies par l’expression et ses options.

## **Collecter les informations de correspondance avec un callback**

Implémentez [IFindResultCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifindresultcallback/) pour recevoir une notification pour chaque correspondance. Sa méthode [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifindresultcallback/foundresult/) fournit le cadre de texte concerné, le texte source, le texte trouvé et la position de la correspondance.

Le callback ne reçoit pas directement le numéro de diapositive. L’implémentation ci‑dessous le dérive de [ISlideComponent::get_Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecomponent/get_slide/) et gère également le texte trouvé dans les notes de diapositive via [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inotesslide/get_parentslide/). Un numéro de diapositive nullable permet au même modèle de résultat de représenter du texte associé à d’autres types de diapositives.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Pour les opérations de remplacement, `FoundText` contient le texte original correspondant, de sorte que le callback peut enregistrer exactement quels termes ont été remplacés.

## **Mettre en évidence le texte**

Utilisez la méthode [ITextFrame::HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlighttext/) pour mettre en évidence les correspondances de texte littéral dans un cadre de texte. Passez un [ITextSearchOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/) pour contrôler la recherche et un callback pour collecter les détails des correspondances.

L’exemple de code ci‑dessous met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**. Les deux recherches rapportent leurs correspondances au même callback.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence le texte à l’aide d’expressions régulières**

La méthode [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlightregex/) met en évidence les correspondances de texte trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en évidence tous les mots contenant sept caractères ou plus et collecte chaque correspondance :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le texte mis en évidence à l'aide de l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en évidence le texte dans toute une présentation**

Utilisez [IPresentation::HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/highlighttext/) et [IPresentation::HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/highlightregex/) pour rechercher tous les cadres de texte applicables dans une présentation. L’exemple suivant met en évidence un terme littéral et toutes les adresses e‑mail tout en conservant des collections de résultats distinctes pour les deux recherches.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remplacer le texte dans un cadre de texte**

Utilisez [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replacetext/) pour le texte littéral et [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replaceregex/) pour le remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant à l’intérieur du cadre de texte existant, qui conserve le formatage de la portion environnante au lieu de reconstruire le cadre de texte à partir d’une chaîne brute.

L’exemple suivant standardise une variante orthographique puis remplace les libellés de version. Le même callback enregistre les termes originaux correspondants aux deux opérations.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si une correspondance s’étend sur des portions avec un formatage différent, examinez le résultat pour confirmer quel format doit s’appliquer au texte de remplacement.

## **Remplacer le texte dans toute une présentation**

Utilisez [IPresentation::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/replacetext/) et [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/replaceregex/) pour appliquer les mêmes opérations à travers la présentation. Ceci est utile pour le nettoyage de modèles, les mises à jour de terminologie et la censure.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Grouper les correspondances pour le reporting**

Comme chaque résultat stocke son numéro de diapositive et son cadre de texte, les applications peuvent regrouper les correspondances pour l’audit, le reporting ou les flux de travail de révision. L’exemple suivant regroupe les résultats collectés d’abord par diapositive, puis par cadre de texte :

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **FAQ**

**Comment puis‑je rechercher uniquement une zone de texte plutôt que toute la présentation ?**

Obtenez le cadre de texte de la forme et appelez [ITextFrame::HighlightText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replacetext/) ou [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replaceregex/) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent toutes les zones de texte applicables à la place.

**Comment puis‑je faire correspondre des mots complets avec la casse correcte ?**

Appelez [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) et [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) avec `true`, puis transmettez les options à une méthode de mise en évidence ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `System::Text::RegularExpressions::Regex`.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Appelez [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextsearchoptions/set_includenotes/) avec `true` lors de l’utilisation d’une opération de texte littéral au niveau de la présentation. L’implémentation du callback présentée ci‑dessus associe une correspondance dans une note de diapositive à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez une implémentation de [IFindResultCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifindresultcallback/) à l’opération de mise en évidence ou de remplacement. Le callback reçoit chaque correspondance pendant l’exécution de l’opération, ce qui permet à l’application de stocker le texte source, le texte trouvé, la position, le cadre de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte préserve‑t‑il son formatage ?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replacetext/) et [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/replaceregex/) modifient le texte correspondant à l’intérieur du cadre de texte existant et conservent le formatage de la portion environnante. Si une correspondance couvre des portions avec un formatage différent, inspectez le résultat pour vous assurer que le remplacement utilise le style souhaité.