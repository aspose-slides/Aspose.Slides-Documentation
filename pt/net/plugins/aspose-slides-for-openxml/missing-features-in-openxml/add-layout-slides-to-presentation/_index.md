---
title: Adicionar Slides de Layout à Apresentação
type: docs
weight: 20
url: /pt/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET permite que os desenvolvedores adicionem novos slides de Layout em uma apresentação. Para adicionar um Slide de Layout, siga as etapas abaixo:

- Crie uma instância da classe Presentation
- Acesse a coleção de Master Slides
- Tente encontrar slides de Layout existentes para verificar se o necessário já está disponível na coleção de Slides de Layout ou não
- Adicione um novo slide de Layout se o layout desejado não estiver disponível
- Adicione um slide em branco com o slide de Layout recém‑adicionado
- Por fim, grave o arquivo da apresentação usando o objeto Presentation

## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instanciar a classe Presentation que representa o arquivo de apresentação

using (Presentation p = new Presentation(FileName))

{
    // Tentar buscar pelo tipo de slide de layout
    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide =
        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
        layoutSlides.GetByType(SlideLayoutType.Title);
    if (layoutSlide == null)
    {
        // A situação quando uma apresentação não contém alguns tipos de layouts.
        // A apresentação Technographics.pptx contém apenas tipos de layout Blank e Custom.
        // Mas slides de layout com tipos Custom têm nomes de slide diferentes,
        // como "Title", "Title and Content", etc. E é possível usar estes
        // nomes para a seleção de slide de layout.
        // Também é possível usar o conjunto de tipos de forma placeholder. Por exemplo,
        // O slide de título deve ter apenas o tipo de placeholder Title, etc.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }
    //Adicionando slide vazio com o slide de layout adicionado 
    p.Slides.InsertEmptySlide(0, layoutSlide);
    //Salvar apresentação    
    p.Save(FileName, SaveFormat.Pptx);
}
``` 

## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)

## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
Para mais detalhes, visite [Aplicar ou Alterar Layouts de Slide em .NET](/slides/pt/net/slide-layout/).
{{% /alert %}}