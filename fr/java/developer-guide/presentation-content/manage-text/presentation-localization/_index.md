---
title: Automatiser la localisation des présentations en Java
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/java/presentation-localization/
keywords:
- changer de langue
- vérification orthographique
- désactiver la vérification orthographique
- langue de vérification
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Définissez les langues de vérification pour le texte des présentations PowerPoint et OpenDocument en Java avec Aspose.Slides, y compris les paramètres par défaut et les paragraphes multilingues."
---
## **Vue d'ensemble**

Aspose.Slides for Java vous permet de configurer les métadonnées de vérification pour des portions de texte individuelles. Utilisez [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) pour identifier la langue de vérification, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) pour autoriser ou supprimer les vérifications orthographiques, et [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) pour contrôler l’état plus large « ne pas vérifier ». Parce que ces paramètres sont appliqués au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de vérification.

Cet article explique comment attribuer une langue à un texte spécifique, définir la langue par défaut pour le nouveau texte avec [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), créer des paragraphes multilingues, choisir entre `SpellCheck` et `ProofDisabled`, et conserver les paramètres souhaités lors de l’utilisation de [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de vérification pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/), accédez à la portion de texte requise via [IPortion.getPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#getPortionFormat--), et attribuez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de vérification, et enregistre le résultat avec [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour spécifier la langue de vérification qu’Aspose.Slides attribuera au texte nouvellement créé. Ce paramètre est utile lorsque la plupart ou la totalité du nouveau texte d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le nouveau texte utilise les règles de vérification allemandes :

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/portion/) distincte pour chaque langue et définissez son `LanguageId` indépendamment.

Cet exemple crée un paragraphe avec des portions en anglais et en français :

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Activer ou supprimer la vérification orthographique pour des portions individuelles**

[IPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/) hérite des propriétés de texte communes définies par [IBasePortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/). Accédez au format d’une portion via [IPortion.getPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#getPortionFormat--) et utilisez [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `false` : `true` autorise la vérification orthographique, tandis que `false` la supprime.

Le paramètre s’applique aux portions de texte individuelles. Des portions différentes dans le même paragraphe peuvent donc utiliser des valeurs différentes. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) et `setSpellCheck` remplissent des fonctions complémentaires : `setLanguageId` identifie la langue de vérification, tandis que `setSpellCheck` détermine si les vérifications orthographiques sont autorisées pour la portion.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) contrôle également la vérification, mais il représente l’état plus large « ne pas vérifier » sous forme de [NullableBool](https://reference.aspose.com/slides/fr/java/com.aspose.slides/nullablebool/). Utilisez `setSpellCheck` lorsque vous avez besoin d’un commutateur booléen direct spécifiquement pour les vérifications orthographiques. Utilisez `setProofDisabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées de non‑vérification de la présentation, y compris son état `NotDefined`. Si vous définissez les deux propriétés, gardez leurs valeurs cohérentes ; ne combinez pas `setSpellCheck(true)` avec `setProofDisabled(NullableBool.True)`.

Ces propriétés configurent les métadonnées de vérification utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ni pour renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, attribue différents paramètres de vérification orthographique et langues de vérification à deux portions du même paragraphe, enregistre le résultat, le rouvre et vérifie les valeurs stockées :

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combine les portions adjacentes qui ont le même formatage. Une différence uniquement sur `SpellCheck` ne suffit pas à maintenir ces portions séparées ; après leur fusion, la portion résultante conserve la valeur `SpellCheck` de la première portion. Si les portions doivent avoir des paramètres de vérification différents, appelez `joinPortionsWithSameFormatting` avant d’attribuer ces paramètres, ou inspectez les limites de la portion résultante et réappliquez les paramètres ensuite. Les portions avec des valeurs `LanguageId` différentes restent séparées parce que leur formatage de langue de vérification diffère.

## **FAQ**

**L'identifiant de langue traduit-il le texte ?**

Non. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) stocke des métadonnées de vérification pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de vérification contrôle-t-elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue sert à la vérification. Le rendu du texte et la mise en page dépendent principalement des [polices](/slides/fr/java/powerpoint-fonts/) disponibles, du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [substitution de police](/slides/fr/java/font-substitution/), ou [intégrez les polices](/slides/fr/java/embedded-font/) dans la présentation.

**Un paragraphe peut-il utiliser plusieurs langues de vérification ?**

Oui. Attribuez chaque langue à une portion distincte, comme illustré dans l’exemple de paragraphe multilingue.

**Dois-je utiliser `setDefaultTextLanguage` ou `setLanguageId` ?**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) lorsque vous voulez une langue par défaut pour le texte nouvellement créé. Utilisez [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) lorsqu’une portion spécifique nécessite une langue de vérification explicite ou lorsqu’un paragraphe contient plusieurs langues.