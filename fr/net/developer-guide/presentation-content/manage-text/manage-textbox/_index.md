---
title: Gérer les zones de texte dans les présentations en .NET
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/net/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides pour .NET facilite la création, la modification et la duplication de zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi l'automatisation de vos présentations."
---

Les textes sur les diapositives existent généralement dans des zones de texte ou des formes. Par conséquent, pour ajouter du texte à une diapositive, vous devez d'abord ajouter une zone de texte, puis y mettre du texte. 

Pour vous permettre d'ajouter une forme pouvant contenir du texte, Aspose.Slides for .NET fournit l'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides fournit également l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) pour vous permettre d'ajouter des formes aux diapositives. Cependant, toutes les formes ajoutées via l'interface `IShape` ne peuvent pas contenir de texte. Les formes ajoutées via l'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) contiennent généralement du texte. 

Par conséquent, lorsqu'il s'agit d'une forme existante à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu'elle a été castée via l'interface `IAutoShape`. Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), qui est une propriété de `IAutoShape`. Consultez la section [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) de cette page. 

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenez la référence de la première diapositive via son index. 
3. Ajoutez un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) avec la propriété [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) définie sur `Rectangle` à une position spécifiée sur la diapositive et obtenez la référence de l'objet `IAutoShape` nouvellement ajouté. 
4. Ajoutez la propriété `TextFrame` à l'objet `IAutoShape` qui contiendra du texte. Dans l'exemple ci‑dessous, nous avons ajouté ce texte : *Aspose TextBox*
5. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code C# — une implémentation des étapes ci‑dessus — montre comment ajouter du texte à une diapositive :
```c#
// Instancie PresentationEx
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive de la présentation
    ISlide sld = pres.Slides[0];

    // Ajoute une AutoShape avec le type défini sur Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Ajoute un TextFrame au rectangle
    ashp.AddTextFrame(" ");

    // Accède au cadre de texte
    ITextFrame txtFrame = ashp.TextFrame;

    // Crée l'objet Paragraph pour le cadre de texte
    IParagraph para = txtFrame.Paragraphs[0];

    // Crée un objet Portion pour le paragraphe
    IPortion portion = para.Portions[0];

    // Définit le texte
    portion.Text = "Aspose TextBox";

    // Enregistre la présentation sur le disque
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Vérifier une forme de zone de texte**

Aspose.Slides fournit la propriété [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) de l'interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) , vous permettant d'examiner les formes et d'identifier les zones de texte.  

![Text box and shape](istextbox.png)

Ce code C# montre comment vérifier si une forme a été créée comme zone de texte :
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```


Notez que si vous ajoutez simplement une forme automatique à l'aide de la méthode `AddAutoShape` de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) , la propriété `IsTextBox` de la forme renverra `false`. Cependant, après avoir ajouté du texte à la forme à l'aide de la méthode `AddTextFrame` ou de la propriété `Text`, la propriété `IsTextBox` renvoie `true`.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox est faux
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox est vrai

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox est faux
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox est vrai

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox est faux
    shape3.AddTextFrame("");
    // shape3.IsTextBox est faux

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox est faux
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox est faux
}
```


## **Ajouter des colonnes à une zone de texte**

Aspose.Slides fournit les propriétés [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) et [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) et de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) pour vous permettre d'ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes dans une zone de texte, puis déterminer l'espacement en points entre les colonnes. 

Ce code en C# démontre l'opération décrite :
```c#
using (Presentation presentation = new Presentation())
{
	// Obtient la première diapositive de la présentation
	ISlide slide = presentation.Slides[0];

	// Ajoute une AutoShape avec le type défini sur Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Ajoute un TextFrame au Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Obtient le format du TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Définit le nombre de colonnes dans le TextFrame
	format.ColumnCount = 3;

	// Définit l'espacement entre les colonnes
	format.ColumnSpacing = 10;

	// Enregistre la présentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Ajouter des colonnes à un cadre de texte**
Aspose.Slides for .NET fournit la propriété [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) (de l'interface [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)) qui permet d'ajouter des colonnes dans les cadres de texte. Grâce à cette propriété, vous pouvez spécifier le nombre de colonnes souhaité dans un cadre de texte. 

Ce code C# montre comment ajouter une colonne à l'intérieur d'un cadre de texte :
```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
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

Aspose.Slides vous permet de modifier ou de mettre à jour le texte contenu dans une zone de texte ou l'ensemble des textes d'une présentation. 

Ce code C# démontre une opération où tous les textes d'une présentation sont mis à jour ou modifiés :
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Vérifie si la forme prend en charge le cadre de texte (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Parcourt les paragraphes du cadre de texte
               {
                   foreach (IPortion portion in paragraph.Portions) //Parcourt chaque portion du paragraphe
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Modifie le texte
                       portion.PortionFormat.FontBold = NullableBool.True; //Modifie le formatage
                   }
               }
           }
       }
   }
  
   //Enregistre la présentation modifiée
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **Ajouter une zone de texte avec un hyperlien** 

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, les utilisateurs sont dirigés vers le lien. 

1. Créez une instance de la classe `Presentation`. 
2. Obtenez la référence de la première diapositive via son index.  
3. Ajoutez un objet `AutoShape` avec `ShapeType` défini sur `Rectangle` à une position spécifiée sur la diapositive et obtenez une référence de l'objet AutoShape nouvellement ajouté.
4. Ajoutez un `TextFrame` à l'objet `AutoShape` contenant *Aspose TextBox* comme texte par défaut. 
5. Instanciez la classe `IHyperlinkManager`. 
6. Attribuez l'objet `IHyperlinkManager` à la propriété [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) associée à la partie souhaitée du `TextFrame`. 
7. Enfin, écrivez le fichier PPTX via l'objet `Presentation`. 

Ce code C# — une implémentation des étapes ci‑dessus — montre comment ajouter une zone de texte avec un hyperlien à une diapositive :
```c#
// Instancie une classe Presentation qui représente un PPTX
// Obtient la première diapositive de la présentation
// Ajoute un objet AutoShape avec le type défini comme Rectangle
// Convertit la forme en AutoShape
// Accède à la propriété ITextFrame associée à l'AutoShape
Presentation pptxPresentation = new Presentation();

ISlide slide = pptxPresentation.Slides[0];

IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Ajoute une zone de texte à l'AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Ajoute du texte au cadre
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Définit le lien hypertexte pour le texte de la portion
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Enregistre la présentation PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lorsqu'on travaille avec les diapositives maîtres ?**

Un [placeholder](/slides/fr/net/manage-placeholder/) hérite du style/position de la [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), tandis qu'une zone de texte ordinaire est un objet indépendant sur une diapositive précise et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement massif de texte dans l’ensemble de la présentation sans toucher au texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux formes automatiques qui possèdent des cadres de texte et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.