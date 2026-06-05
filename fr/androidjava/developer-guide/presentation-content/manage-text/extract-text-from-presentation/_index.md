---
title: Extraction avancée de texte à partir de présentations sur Android
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/androidjava/extract-text-from-presentation/
keywords:
- extraire le texte
- extraire le texte d'une diapositive
- extraire le texte d'une présentation
- extraire le texte de PowerPoint
- extraire le texte d'OpenDocument
- extraire le texte de PPT
- extraire le texte de PPTX
- extraire le texte de ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Extrayez rapidement le texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Android via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Vue d'ensemble**

L'extraction du texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec le contenu des diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), l'accès et la récupération des données textuelles peuvent être cruciaux pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement le texte de différents formats de présentation, notamment PPT, PPTX et ODP, en utilisant Aspose.Slides for Android via Java. Vous apprendrez à parcourir systématiquement les éléments d'une présentation afin de récupérer avec précision le contenu texte dont vous avez besoin.

## **Extraire le texte d'une diapositive**

Aspose.Slides for Android via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées permettant d'extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation, utilisez la méthode [getAllTextBoxes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-). Cette méthode accepte un objet de type [IBaseSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/) en paramètre. Lors de son exécution, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/), en conservant le formatage du texte.

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

## **Extraire le texte d'une présentation**

Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/). Elle accepte deux paramètres :

1. Tout d'abord, un objet [IPresentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.  
2. Deuxièmement, une valeur `boolean` indiquant si les diapositives maîtres doivent être incluses lors de l'analyse du texte de la présentation.

La méthode renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/), incluant les informations de formatage du texte. Le code ci‑dessous analyse le texte et les détails de formatage d'une présentation, y compris les diapositives maîtres.

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

L'argument d'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction du texte et peut prendre les valeurs suivantes :
- `Unarranged` - Le texte brut sans tenir compte de sa position sur la diapositive.  
- `Arranged` - Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la rapidité est primordiale ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Sa méthode `getSlidesText