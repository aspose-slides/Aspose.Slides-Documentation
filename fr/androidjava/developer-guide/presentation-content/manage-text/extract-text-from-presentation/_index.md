---
title: Extraction avancée de texte à partir de présentations sur Android
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/androidjava/extract-text-from-presentation/
keywords:
- extraire le texte
- extraire le texte de la diapositive
- extraire le texte de la présentation
- extraire le texte de PowerPoint
- extraire le texte d'OpenDocument
- extraire le texte de PPT
- extraire le texte de PPTX
- extraire le texte d'ODP
- récupérer le texte
- récupérer le texte de la diapositive
- récupérer le texte de la présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte d'ODP
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides for Android via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Aperçu**

L’extraction de texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec le contenu des diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder aux données textuelles peut être crucial pour l’analyse, l’automatisation, l’indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d’extraire efficacement du texte de divers formats de présentation, y compris PPT, PPTX et ODP, à l’aide d’Aspose.Slides for Android via Java. Vous apprendrez à parcourir systématiquement les éléments d’une présentation pour récupérer correctement le texte dont vous avez besoin.

## **Extraire le texte d’une diapositive**

Aspose.Slides for Android via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d’une présentation ou d’une diapositive. Pour extraire le texte d’une diapositive dans une présentation, utilisez la méthode [getAllTextBoxes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Cette méthode accepte un objet de type [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/) en paramètre. Lorsqu’elle est exécutée, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d’objets de type [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/), en conservant toute mise en forme du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraire le texte d’une présentation**

Pour analyser le texte de l’ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/). Elle accepte deux paramètres :

1. Tout d’abord, un objet [IPresentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.
2. Deuxièmement, une valeur `boolean` indiquant si les diapositives maîtres doivent être incluses lors de l’analyse du texte de la présentation.

La méthode renvoie un tableau d’objets de type [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/), incluant les informations de mise en forme du texte. Le code ci‑dessous analyse le texte et les détails de mise en forme d’une présentation, y compris les diapositives maîtres.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationfactory/) propose également des méthodes pour extraire tout le texte des présentations :

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

L’argument d’énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textextractionarrangingmode/) indique le mode d’organisation du résultat d’extraction de texte et peut être défini sur les valeurs suivantes :
- `Unarranged` – Le texte brut, sans tenir compte de sa position sur la diapositive.
- `Arranged` – Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la rapidité est cruciale ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Sa méthode `getSlidesText` renvoie un tableau d’objets de type [ISlideText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidetext/). Chaque objet représente le texte de la diapositive correspondante. L’objet de type [ISlideText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidetext/) possède les méthodes suivantes :

- `getText` – Le texte contenu dans les formes de la diapositive.
- `getMasterText` – Le texte contenu dans les formes de la diapositive maître associée à cette diapositive.
- `getLayoutText` – Le texte contenu dans les formes de la diapositive de mise en page associée à cette diapositive.
- `getNotesText` – Le texte contenu dans les formes de la diapositive des notes associée à cette diapositive.
- `getCommentsText` – Le texte contenu dans les commentaires associés à cette diapositive.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Quelle est la vitesse de traitement des grandes présentations par Aspose.Slides lors de l’extraction de texte ?**

Aspose.Slides est optimisé pour de hautes performances et peut traiter même les [grandes présentations](/slides/fr/androidjava/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en lot.

**Aspose.Slides peut‑il extraire le texte des tableaux et graphiques dans les présentations ?**

Oui. Aspose.Slides peut extraire le texte de nombreux éléments de diapositive, y compris les tableaux et les objets liés aux graphiques, de sorte que vous puissiez accéder et analyser le contenu textuel des structures de présentation courantes.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte en utilisant la version d’essai gratuite d’Aspose.Slides, bien qu’elle comporte [certaines limitations](/slides/fr/androidjava/licensing/), comme le traitement d’un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer des présentations plus volumineuses, l’achat d’une licence complète est recommandé.