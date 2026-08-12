---
title: Recherche et remplacement de texte dans les présentations PowerPoint en .NET
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/net/search-and-replace-text/
keywords:
- recherche de texte
- mise en évidence du texte
- remplacement de texte
- expression régulière
- rappel de résultat
- trame de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Recherchez, mettez en évidence et remplacez du texte dans des présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut rechercher, mettre en évidence et remplacer du texte dans une trame de texte individuelle ou dans l'ensemble d'une présentation. Chaque opération peut également notifier une application de chaque correspondance via une fonction de rappel de résultat. Cela permet de mettre à jour une présentation et de créer simultanément une trace d’audit contenant le texte trouvé, son contexte, sa position, la trame de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la rédaction, la vérification de la terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci-dessous, nous utilisons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de ITextFrame pour limiter une opération à une seule trame de texte. Utilisez les méthodes de Presentation pour traiter tout le texte applicable dans la présentation.

| Opération | Une trame de texte | Présentation entière |
|---|---|---|
| Mettre en évidence le texte littéral | [ITextFrame.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlighttext/) |
| Mettre en évidence les correspondances d'expressions régulières | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlightregex/) |
| Remplacer le texte littéral | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replacetext/) |
| Remplacer les correspondances d'expressions régulières | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replaceregex/) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez TextSearchOptions pour contrôler la correspondance :

- TextSearchOptions.WholeWordsOnly limite les correspondances aux mots complets.
- TextSearchOptions.CaseSensitive contrôle si la casse des caractères doit correspondre.
- TextSearchOptions.IncludeNotes inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en évidence au niveau de la présentation.

Les opérations d'expressions régulières utilisent un `Regex` .NET, de sorte que les règles de correspondance comme la sensibilité à la casse et les limites de mots sont définies par l'expression et ses options.

## **Collecter les informations de correspondance avec un rappel**

Implémentez IFindResultCallback pour recevoir une notification pour chaque correspondance. Sa méthode IFindResultCallback.FoundResult fournit la trame de texte associée, le texte source, le texte trouvé et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L'implémentation ci-dessous le dérive de la diapositive parent et gère également le texte trouvé dans les notes de diapositive. Un numéro de diapositive nullable permet au même modèle de résultat de représenter du texte associé à d'autres types de diapositives.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Pour les opérations de remplacement, `FoundText` contient le texte original correspondant, de sorte que le rappel peut enregistrer exactement quels termes ont été remplacés.

## **Mettre en évidence le texte**

Utilisez la méthode ITextFrame.HighlightText pour mettre en évidence les correspondances de texte littéral dans une trame de texte. Passez TextSearchOptions pour contrôler la recherche et un rappel pour collecter les détails des correspondances.

L'exemple de code ci-dessous met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**. Les deux recherches signalent leurs correspondances au même rappel.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Obtenez la première forme de la première diapositive.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Mettez en évidence chaque occurrence de "try" dans la trame de texte.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Mettez en évidence uniquement le mot complet "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence le texte à l'aide d'expressions régulières**

La méthode ITextFrame.HighlightRegex met en évidence les correspondances de texte trouvées par une expression régulière dans une trame de texte.

Le code suivant met en évidence tous les mots contenant sept caractères ou plus et collecte chaque correspondance :

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le texte mis en évidence avec l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en évidence le texte dans une présentation**

Utilisez Presentation.HighlightText et Presentation.HighlightRegex pour rechercher toutes les trames de texte applicables dans une présentation. L'exemple suivant met en évidence un terme littéral et toutes les adresses e‑mail tout en conservant des collections de résultats séparées pour les deux recherches.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Remplacer le texte dans une trame de texte**

Utilisez ITextFrame.ReplaceText pour le texte littéral et ITextFrame.ReplaceRegex pour le remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant dans la trame de texte existante, qui conserve le formatage de la portion environnante au lieu de reconstruire la trame de texte à partir d'une chaîne brute.

L'exemple suivant normalise une variante orthographique puis remplace les étiquettes de version. Le même rappel enregistre les termes originaux correspondants aux deux opérations.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Si une correspondance couvre des parties avec un formatage différent, examinez le résultat pour confirmer quel formatage doit être appliqué au texte de remplacement.

## **Remplacer le texte dans une présentation**

Utilisez Presentation.ReplaceText et Presentation.ReplaceRegex pour appliquer les mêmes opérations à travers la présentation. Cela est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Regrouper les correspondances pour le reporting**

Étant donné que chaque résultat stocke son numéro de diapositive et sa trame de texte, les applications peuvent regrouper les correspondances pour l'audit, les rapports ou les flux de travail de révision. L'exemple suivant regroupe les résultats collectés d'abord par diapositive, puis par trame de texte :

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**Comment puis‑je rechercher uniquement une zone de texte au lieu de toute la présentation ?**

Obtenez la trame de texte de la forme et appelez ITextFrame.HighlightText, ITextFrame.HighlightRegex, ITextFrame.ReplaceText ou ITextFrame.ReplaceRegex sur cette trame de texte. Les méthodes au niveau de la présentation traitent toutes les trames de texte applicables à la place.

**Comment puis‑je correspondre à des mots complets avec la bonne capitalisation ?**

Définissez TextSearchOptions.WholeWordsOnly et TextSearchOptions.CaseSensitive à `true`, et transmettez les options à une méthode de mise en évidence ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `Regex` .NET.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositives ?**

Oui. Définissez TextSearchOptions.IncludeNotes à `true` lors de l'utilisation d'une opération de texte littéral au niveau de la présentation. L'implémentation du rappel présentée ci‑dessus associe une correspondance dans une diapositive de notes à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez une implémentation de IFindResultCallback à l'opération de mise en évidence ou de remplacement. Le rappel reçoit chaque correspondance pendant l'exécution de l'opération, de sorte que l'application peut stocker le texte source, le texte correspondant, la position, la trame de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte préserve‑t‑il son formatage ?**

ITextFrame.ReplaceText et ITextFrame.ReplaceRegex modifient le texte correspondant à l'intérieur de la trame de texte existante et conservent le formatage de la portion environnante. Si une correspondance couvre des parties avec un formatage différent, examinez le résultat pour vous assurer que le remplacement utilise le style souhaité.