---
title: Aplicar um tema a uma apresentação
type: docs
weight: 30
url: /pt/net/apply-a-theme-to-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Aplicar um novo tema à apresentação. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Aplicar um novo tema à apresentação. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Obter a parte de apresentação do documento de apresentação.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obter a parte mestre de slides existente.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Obter a nova parte mestre de slides.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Remover a parte de tema existente.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Remover a antiga parte mestre de slides.

    presentationPart.DeletePart(slideMasterPart);

    // Importar a nova parte mestre de slides e reutilizar o ID de relacionamento antigo.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Alterar para a nova parte de tema.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Inserir o código para o layout neste exemplo.

    string defaultLayoutType = "Title and Content";

    // Remover o relacionamento de layout de slide em todos os slides. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determinar o tipo de layout de slide para cada slide.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Excluir a antiga parte de layout.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Aplicar a nova parte de layout.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Aplicar a nova parte de layout padrão.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Obter o tipo de layout de slide.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Observação: Se isto for usado em código de produção, verifique se há referência nula.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Para aplicar um tema, precisamos clonar o slide com o mestre, siga os passos abaixo:

- Crie uma instância da classe Presentation contendo a apresentação origem da qual o slide será clonado.
- Crie uma instância da classe Presentation contendo a apresentação de destino para a qual o slide será clonado.
- Acesse o slide a ser clonado juntamente com o slide mestre.
- Instancie a classe IMasterSlideCollection referenciando a coleção Masters exposta pelo objeto Presentation da apresentação de destino.
- Chame o método AddClone exposto pelo objeto IMasterSlideCollection e passe o mestre do PPTX de origem a ser clonado como parâmetro para o método AddClone.
- Instancie a classe ISlideCollection definindo a referência para a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
- Chame o método AddClone exposto pelo objeto ISlideCollection e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetro para o método AddClone.
- Grave o arquivo da apresentação de destino modificada.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instanciar a classe Presentation para carregar o arquivo de apresentação origem
    Presentation srcPres = new Presentation(presentationFile);
    //Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    Presentation destPres = new Presentation(outputFile);
    //Instanciar ISlide a partir da coleção de slides na apresentação origem juntamente com
    //slide mestre
    ISlide SourceSlide = srcPres.Slides[0];
    //Clonar o slide mestre desejado da apresentação origem para a coleção de mestres em
    //apresentação de destino
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //Clonar o slide mestre desejado da apresentação origem para a coleção de mestres em
    //apresentação de destino
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //Clonar o slide desejado da apresentação origem com o mestre desejado até o final da
    //coleção de slides na apresentação de destino
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //Clonar o slide mestre desejado da apresentação origem para a coleção de mestres na//apresentação de destino
    //Salvar a apresentação de destino no disco
    destPres.Save(outputFile, SaveFormat.Pptx);
}

``` 
## **Exemplo de Código em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)