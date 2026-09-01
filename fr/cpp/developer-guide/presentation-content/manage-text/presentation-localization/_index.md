---
title: Automatiser la localisation de présentations en C++
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/cpp/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- supprimer la vérification orthographique
- langue de vérification
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Définir les langues de vérification pour le texte des présentations PowerPoint et OpenDocument en C++ avec Aspose.Slides, y compris les valeurs par défaut et les paragraphes multilingues."
---
## **Vue d'ensemble**

Aspose.Slides for C++ vous permet de configurer les métadonnées de vérification pour des portions de texte individuelles. Utilisez [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_languageid/) pour identifier la langue de vérification, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_spellcheck/) pour autoriser ou supprimer les vérifications orthographiques, et [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_proofdisabled/) pour contrôler l’état plus large « pas de vérification ». Comme ces paramètres s’appliquent au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de vérification.

Cet article explique comment affecter une langue à un texte spécifique, définir la langue par défaut pour le nouveau texte avec [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), créer des paragraphes multilingues, choisir entre `SpellCheck` et `ProofDisabled`, et préserver les paramètres souhaités lors de l’utilisation de [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de vérification pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/), accédez à la portion de texte requise via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/get_portionformat/), et affectez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de vérification, et enregistre le résultat avec [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) pour spécifier la langue de vérification qu’Aspose.Slides attribuera au texte créé récemment. Ce réglage est utile lorsque la plupart ou la totalité du nouveau texte d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le nouveau texte utilise les règles de vérification allemandes :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/cpp/aspose.slides/portion/) distincte pour chaque langue et définissez son `LanguageId` indépendamment.

Cet exemple crée un paragraphe avec des portions en anglais et en français :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Activer ou supprimer la vérification orthographique pour les portions individuelles**

[IPortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportionformat/) hérite des propriétés de texte communes définies par [IBasePortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/). Accédez au format d’une portion via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iportion/get_portionformat/) et appelez [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_spellcheck/) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `false` : `true` autorise la vérification, tandis que `false` la supprime.

Le réglage s’applique aux portions de texte individuelles. Des portions différentes dans le même paragraphe peuvent donc utiliser des valeurs distinctes. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_languageid/) et `SpellCheck` ont des fonctions complémentaires : `LanguageId` identifie la langue de vérification, tandis que `SpellCheck` détermine si les vérifications orthographiques sont autorisées pour la portion.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_proofdisabled/) contrôle également la vérification, mais il représente l’état plus large « ne pas vérifier » sous forme de [NullableBool](https://reference.aspose.com/slides/fr/cpp/aspose.slides/nullablebool/). Utilisez `SpellCheck` lorsque vous avez besoin d’un interrupteur booléen direct spécifiquement pour les vérifications orthographiques. Utilisez `ProofDisabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées « pas de vérification » de la présentation, y compris son état `NullableBool::NotDefined`. Si vous définissez les deux propriétés, maintenez leurs valeurs cohérentes ; ne combinez pas `SpellCheck = true` avec `ProofDisabled = NullableBool::True`.

Ces propriétés configurent les métadonnées de vérification utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ni pour renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, affecte des réglages de vérification orthographique et des langues de vérification différents à deux portions du même paragraphe, enregistre le résultat, le rouvre et vérifie les valeurs stockées :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combine les portions adjacentes qui ont le même formatage. Une différence uniquement dans `SpellCheck` ne maintient pas les portions séparées ; après la fusion, la portion résultante conserve la valeur `SpellCheck` de la première portion. Si les portions nécessitent des réglages de vérification différents, appelez `JoinPortionsWithSameFormatting` avant d’affecter ces réglages, ou examinez les frontières des portions résultantes et réappliquez les réglages par la suite. Les portions avec des valeurs `LanguageId` différentes restent séparées car leur formatage de langue de vérification diffère.

## **FAQ**

**Un identifiant de langue traduit-il le texte ?**

Non. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_languageid/) stocke des métadonnées de vérification pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de vérification contrôle-t-elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue sert à la vérification. Le rendu du texte et la mise en page dépendent principalement des [polices](/slides/fr/cpp/powerpoint-fonts/), du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [substitution de police](/slides/fr/cpp/font-substitution/), ou [intégrez des polices](/slides/fr/cpp/embedded-font/) dans la présentation.

**Un paragraphe peut-il utiliser plusieurs langues de vérification ?**

Oui. Affectez chaque langue à une portion distincte, comme le montre l’exemple de paragraphe multilingue.

**Dois‑je utiliser `DefaultTextLanguage` ou `LanguageId` ?**

Utilisez [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) lorsque vous souhaitez une valeur par défaut pour le texte nouvellement créé. Utilisez [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_languageid/) lorsqu’une portion spécifique nécessite une langue de vérification explicite ou lorsqu’un paragraphe contient plusieurs langues.