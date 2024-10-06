---
title: Extraction de texte depuis la présentation
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes sur toutes les diapositives d'une présentation. Cet article explique comment extraire du texte des présentations Microsoft PowerPoint PPTX en utilisant Aspose.Slides. Le texte peut être extrait de plusieurs manières :

[Extraction de texte d'une diapositive](/slides/cpp/extracting-text-from-the-presentation/)
[Extraction de texte utilisant la méthode GetAllTextBoxes](/slides/cpp/extracting-text-from-the-presentation/)
[Extraction de texte classée et rapide](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraction de texte d'une diapositive**
Aspose.Slides pour C++ fournit l'espace de noms Aspose.Slides.Util qui comprend la classe PresentationScanner. Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) exposée par la classe PresentationScanner. Cette méthode accepte l'objet Slide comme paramètre.
Lors de l'exécution, la méthode Slide scanne tout le texte de la diapositive passée comme paramètre et retourne un tableau d'objets TextFrame. Cela signifie que tout formatage de texte associé au texte est disponible. Le morceau de code suivant extrait tout le texte de la première diapositive de la présentation :

**C#**

``` cpp

 //Instancier la classe PresentationEx qui représente un fichier PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Obtenir un tableau d'objets TextFrameEx de la première diapositive

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Boucle à travers le tableau d'objets TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Boucle à travers les paragraphes dans le TextFrame actuel

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Boucle à travers les portions dans le paragraphe actuel

        foreach (Portion port in para.Portions)

        {

            //Afficher le texte dans la portion actuelle

            Console.WriteLine(port.Text);

            //Afficher la hauteur de la police du texte

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Afficher le nom de la police du texte

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **Extraction de texte de l'ensemble de la présentation**
Pour scanner le texte de l'ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) exposée par la classe PresentationScanner. Elle prend deux paramètres :

1. D'abord, un objet Presentation qui représente la présentation PPTX dont le texte est extrait.
2. Ensuite, une valeur booléenne déterminant si la diapositive maître doit être incluse lors du scan du texte de la présentation.
   La méthode retourne un tableau d'objets TextFrame, complet avec des informations de formatage de texte. Le code ci-dessous scanne le texte et les informations de formatage d'une présentation, y compris les diapositives maîtresses.

**C#**

``` cpp

 //Instancier la classe Presentation qui représente un fichier PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");
//Obtenir un tableau d'objets ITextFrame de toutes les diapositives dans le PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Boucle à travers le tableau d'objets TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //Boucle à travers les paragraphes dans le ITextFrame actuel

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Boucle à travers les portions dans le IParagraph actuel

        foreach (IPortion port in para.Portions)

        {

            //Afficher le texte dans la portion actuelle

            Console.WriteLine(port.Text);

            //Afficher la hauteur de la police du texte

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Afficher le nom de la police du texte

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **Extraction de texte classée et rapide**
La nouvelle méthode statique GetPresentationText a été ajoutée à la classe Presentation. Il y a deux surcharges pour cette méthode :

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```

L'argument enum ExtractionMode indique le mode pour organiser la sortie du résultat de texte et peut être défini sur les valeurs suivantes :
Non organisé - Le texte brut sans respect de la position sur la diapositive
Organisé - Le texte est positionné dans le même ordre que sur la diapositive

Le mode non organisé peut être utilisé lorsque la vitesse est critique, il est plus rapide que le mode organisé.

PresentationText représente le texte brut extrait de la présentation. Il contient une propriété SlidesText de l'espace de noms Aspose.Slides.Util qui retourne un tableau d'objets ISlideText. Chaque objet représente le texte sur la diapositive correspondante. L'objet ISlideText a les propriétés suivantes :

ISlideText.Text - Le texte sur les formes de la diapositive
ISlideText.MasterText - Le texte sur les formes de la page maître pour cette diapositive
ISlideText.LayoutText - Le texte sur les formes de la page de mise en page pour cette diapositive
ISlideText.NotesText - Le texte sur les formes de la page de notes pour cette diapositive

Il existe également une classe SlideText qui implémente l'interface ISlideText.

La nouvelle API peut être utilisée comme suit :

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```