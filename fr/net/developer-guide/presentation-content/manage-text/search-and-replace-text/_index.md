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
- zone de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Recherchez, mettez en évidence et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides pour .NET."
---
## **Aperçu**

Aspose.Slides for .NET peut rechercher, mettre en évidence et remplacer du texte dans une zone de texte individuelle ou dans toute la présentation. Chaque opération peut également notifier une application de chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation tout en générant simultanément une trace d’audit contenant le texte correspondant, son contexte, sa position, la zone de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la rédaction, la vérification de la terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de recherche**

Utilisez les méthodes de [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) pour limiter une opération à une seule zone de texte. Utilisez les méthodes de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) pour traiter l’ensemble du texte applicable dans la présentation.

| Opération | Une zone de texte | Toute la présentation |
|---|---|---|
| Mettre en évidence le texte littéral | [ITextFrame.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlighttext/) |
| Mettre en évidence les correspondances d'expression régulière | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlightregex/) |
| Remplacer le texte littéral | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replacetext/) |
| Remplacer les correspondances d'expression régulière | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replaceregex/) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/) pour contrôler la correspondance :

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/wholewordsonly/) limite les correspondances aux mots complets.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/casesensitive/) détermine si la casse des caractères doit correspondre.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/includenotes/) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en évidence au niveau de la présentation.

Les opérations d’expression régulière utilisent un `Regex` .NET, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l’expression et ses options.

## **Identifier le propriétaire d’une zone de texte**

Les flux de travail génériques de traitement de texte reçoivent souvent un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) lors de la recherche, du remplacement, de la validation ou de l’exportation du texte. Utilisez [ITextFrame.ParentShape](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentshape/) et [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) pour déterminer quel objet de la présentation possède la zone de texte.

Les valeurs attendues dépendent du propriétaire :

| Propriétaire de la zone de texte | `ParentShape` | `ParentCell` |
|---|---|---|
| Une AutoShape ou une autre forme contenant du texte | Le [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) propriétaire | `null` |
| Une cellule de tableau | `null` | Le [ICell](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/) propriétaire |

Les deux propriétés sont des propriétés de navigation en lecture seule. Les lire ne déplace pas la zone de texte ni ne change son propriétaire. Le code générique doit vérifier que les deux valeurs sont `null` et gérer la possibilité qu’aucun propriétaire ne soit disponible.

L’exemple suivant utilise [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/getalltextframes/) pour parcourir les zones de texte d’une présentation. Pour les formes, il indique le nom de la forme, le type de forme et la diapositive contenant. Pour les cellules de tableau, il indique les coordonnées de colonne et de ligne (à partir de zéro) et la diapositive contenant.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Pour le contenu SmartArt, parcourez les formes dans [ISmartArtNode.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartartnode/shapes/) et accédez à chaque [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartartshape/textframe/). La zone de texte peut être retracée jusqu’à sa forme associée via [ITextFrame.ParentShape](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentshape/), tandis que [ITextFrame.ParentCell](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/parentcell/) est `null`. Ainsi, la branche forme de l’exemple gère également le texte des nœuds SmartArt.

## **Collecter les informations de correspondance avec un rappel**

Implémentez [IFindResultCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/ifindresultcallback/) pour recevoir une notification pour chaque correspondance. Sa méthode [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/fr/net/aspose.slides/ifindresultcallback/foundresult/) fournit la zone de texte concernée, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L’implémentation ci‑dessous le déduit de la diapositive parente et gère également le texte trouvé dans les notes de diapositive. Un numéro de diapositive nullable permet au même modèle de résultat de représenter le texte associé à d’autres types de diapositives.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

## **Mettre en évidence du texte**

Utilisez la méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlighttext/) pour mettre en évidence les correspondances de texte littéral dans une zone de texte. Passez [TextSearchOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/) pour contrôler la recherche et un rappel pour collecter les détails des correspondances.

L’exemple de code ci‑dessus met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**. Les deux recherches signalent leurs correspondances au même rappel.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Obtenir la première forme de la première diapositive.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Mettre en évidence chaque occurrence de "try" dans la zone de texte.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Mettre en évidence uniquement le mot complet "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence du texte avec des expressions régulières**

La méthode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlightregex/) met en évidence les correspondances de texte trouvées par une expression régulière dans une zone de texte.

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

![Le texte mis en évidence à l’aide de l’expression régulière](highlighted_text_using_regex.png)

## **Mettre en évidence du texte dans toute une présentation**

Utilisez [Presentation.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlighttext/) et [Presentation.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/highlightregex/) pour rechercher toutes les zones de texte applicables dans une présentation. L’exemple suivant met en évidence un terme littéral et toutes les adresses e‑mail tout en conservant des collections de résultats distinctes pour les deux recherches.

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

## **Remplacer du texte dans une zone de texte**

Utilisez [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replacetext/) pour le texte littéral et [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replaceregex/) pour le remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant à l’intérieur de la zone de texte existante, qui conserve le formatage de la portion environnante au lieu de reconstruire la zone de texte à partir d’une chaîne brute.

L’exemple suivant normalise une variante orthographique puis remplace les libellés de version. Le même rappel enregistre les termes originaux correspondants aux deux opérations.

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

## **Remplacer du texte dans toute une présentation**

Utilisez [Presentation.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replacetext/) et [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replaceregex/) pour appliquer les mêmes opérations à l’ensemble de la présentation. Cela est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

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

Puisque chaque résultat stocke son numéro de diapositive et sa zone de texte, les applications peuvent regrouper les correspondances pour l’audit, le reporting ou les flux de travail de révision. L’exemple suivant regroupe les résultats collectés d’abord par diapositive, puis par zone de texte :

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

Obtenez la zone de texte de la forme et appelez [ITextFrame.HighlightText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replacetext/) ou [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replaceregex/) sur cette zone de texte. Les méthodes au niveau de la présentation traitent toutes les zones de texte applicables à la place.

**Comment puis‑je faire correspondre des mots complets avec la bonne capitalisation ?**

Définissez [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/wholewordsonly/) et [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/casesensitive/) sur `true`, puis passez ces options à une méthode de mise en évidence ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `Regex` .NET.

**La recherche et le remplacement peuvent-ils inclure le texte des notes de diapositive ?**

Oui. Définissez [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fr/net/aspose.slides/textsearchoptions/includenotes/) sur `true` lors de l’utilisation d’une opération de texte littéral au niveau de la présentation. L’implémentation du rappel présentée ci‑dessus associe une correspondance dans une diapositive de notes à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez une implémentation de [IFindResultCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/ifindresultcallback/) à l’opération de mise en évidence ou de remplacement. Le rappel reçoit chaque correspondance pendant l’exécution de l’opération, de sorte que l’application peut stocker le texte source, le texte correspondant, la position, la zone de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte conserve‑t‑il son formatage ?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replacetext/) et [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/replaceregex/) modifient le texte correspondant à l’intérieur de la zone de texte existante et conservent le formatage de la portion environnante. Si une correspondance couvre des parties avec des formatages différents, inspectez le résultat pour vous assurer que le remplacement utilise le style souhaité.