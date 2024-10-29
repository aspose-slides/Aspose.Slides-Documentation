---
title: Gérer le TextBox
type: docs
weight: 20
url: /fr/net/manage-textbox/
keywords: "Textbox, Cadre de texte, Ajouter un textbox, Textbox avec lien hypertexte, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter un textbox ou un cadre de texte aux présentations PowerPoint en C# ou .NET"
---

Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez d'abord ajouter un textbox et ensuite placer du texte à l'intérieur du textbox.

Pour vous permettre d'ajouter une forme pouvant contenir du texte, Aspose.Slides pour .NET fournit l'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).

{{% alert title="Remarque" color="warning" %}}

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) pour vous permettre d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) contiennent généralement du texte.

Par conséquent, lorsque vous traitez avec une forme existante à laquelle vous souhaitez ajouter du texte, vous voudrez peut-être vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'à ce moment-là que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), qui est une propriété sous `IAutoShape`. Consultez la section [Mettre à jour le texte](https://docs.aspose.com/slides/net/manage-textbox/#update-text) sur cette page.

{{% /alert %}}

## **Créer une zone de texte sur la diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence de la première diapositive via son index.
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) avec [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté.
4. Ajoutez une propriété `TextFrame` à l'objet `IAutoShape` qui contiendra du texte. Dans l'exemple ci-dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`.

Ce code C#—une implémentation des étapes ci-dessus—vous montre comment ajouter du texte à une diapositive :

```c#
// Instantiates PresentationEx
using (Presentation pres = new Presentation())
{

    // Gets the first slide in the presentation
    ISlide sld = pres.Slides[0];

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.AddTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.TextFrame;

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.Paragraphs[0];

    // Creates a Portion object for the paragraph
    IPortion portion = para.Portions[0];

    // Sets the text
    portion.Text = "Aspose TextBox";

    // Saves the presentation to disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Vérifier la forme de la zone de texte**

Aspose.Slides fournit la propriété [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) (de la classe [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)) pour vous permettre d'examiner les formes et de trouver des zones de texte.

![Zone de texte et forme](istextbox.png)

Ce code C# vous montre comment vérifier si une forme a été créée en tant que zone de texte :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "la forme est une zone de texte" : "la forme est un texte et non une zone");
        }
    });
}
```

## **Ajouter une colonne dans la zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) et [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) pour vous permettre d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte puis définir l'espacement en points entre les colonnes.

Ce code en C# illustre l'opération décrite :

```c#
using (Presentation presentation = new Presentation())
{
	// Gets the first slide in the presentation
	ISlide slide = presentation.Slides[0];

	// Add an AutoShape with type set as Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Add TextFrame to the Rectangle
	aShape.AddTextFrame("Toutes ces colonnes sont limitées à être dans un seul conteneur de texte -- " +
	"vous pouvez ajouter ou supprimer du texte et le nouveau texte ou le texte restant s'ajuste automatiquement " +
	"pour s'écouler dans le conteneur. Vous ne pouvez pas faire couler le texte d'un conteneur " +
	"à un autre, cependant -- nous vous avons dit que les options de colonnes de PowerPoint pour le texte sont limitées !");

	// Gets the text format of TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specifies the number of columns in TextFrame
	format.ColumnCount = 3;

	// Specifies the spacing between columns
	format.ColumnSpacing = 10;

	// Saves the presentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Ajouter une colonne dans le cadre de texte**

Aspose.Slides pour .NET fournit la propriété [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) qui vous permet d'ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier votre nombre préféré de colonnes dans un cadre de texte.

Ce code C# vous montre comment ajouter une colonne à l'intérieur d'un cadre de texte :

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "Toutes ces colonnes sont contraintes de rester dans un seul conteneur de texte -- " +
                                "vous pouvez ajouter ou supprimer du texte - et le nouveau texte ou le texte restant s'ajuste automatiquement " +
                                "pour rester dans le conteneur. Vous ne pouvez pas faire déborder le texte d'un conteneur " +
                                "à un autre, cependant -- car les options de colonnes de PowerPoint pour le texte sont limitées !";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de changer ou de mettre à jour le texte contenu dans une zone de texte ou tous les textes contenus dans une présentation.

Ce code C# démontre une opération où tous les textes d'une présentation sont mis à jour ou changés :

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Vérifie si la forme prend en charge le cadre de texte (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itère à travers les paragraphes dans le cadre de texte
               {
                   foreach (IPortion portion in paragraph.Portions) //Itère à travers chaque portion dans le paragraphe
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Change le texte
                       portion.PortionFormat.FontBold = NullableBool.True; //Change le formatage
                   }
               }
           }
       }
   }

   //Sauvegarde la présentation modifiée
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Ajouter une zone de texte avec lien hypertexte**

Vous pouvez insérer un lien à l'intérieur d'une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés pour ouvrir le lien.

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence de la première diapositive via son index.
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini comme `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` qui contient *Aspose TextBox* comme texte par défaut.
5. Instanciez la classe `IHyperlinkManager`.
6. Assignez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) associée à votre portion préférée du `TextFrame`.
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`.

Ce code C#—une implémentation des étapes ci-dessus—vous montre comment ajouter une zone de texte avec un lien hypertexte à une diapositive :

```c#
// Instantiates a Presentation class that represents a PPTX
Presentation pptxPresentation = new Presentation();

// Gets the first slide in the presentation
ISlide slide = pptxPresentation.Slides[0];

// Adds an AutoShape object with type set as Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Casts the shape to AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accesses the ITextFrame property associated with the AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adds some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Sets the Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Saves the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```