---
title: Adicionar slide de Layout à Apresentação
type: docs
weight: 10
url: /pt/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET permite que os desenvolvedores adicionem novos slides de Layout em uma apresentação. Para adicionar um Slide de Layout, siga as etapas abaixo:

- Crie uma instância da classe Presentation
- Acesse a coleção Master Slide
- Tente encontrar slides de Layout existentes para verificar se o desejado já está disponível na coleção Layout Slide ou não
- Adicione um novo slide de Layout se o layout desejado não estiver disponível
- Adicione um slide vazio usando o slide de Layout recém‑adicionado
- Por fim, grave o arquivo de apresentação usando o objeto Presentation.

## **Exemplo**
``` csharp

 //Instanciar a classe Presentation que representa o arquivo de apresentação

using (Presentation p = new Presentation("Test.pptx"))

{

   // Tentar buscar pelo tipo de slide de layout

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // A situação quando uma apresentação não contém alguns tipos de layouts.

     // A apresentação Technographics.pptx contém somente tipos de layout Blank e Custom.

     // Mas slides de layout com tipos Custom têm nomes de slide diferentes,

     // como "Title", "Title and Content", etc. E é possível usar estes

     // nomes para a seleção de slide de layout.

     // Também é possível usar o conjunto de tipos de formas placeholder. Por exemplo,

     // O slide de título deve ter apenas o tipo placeholder Title, etc.

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

  //Adicionar slide vazio com o slide de layout adicionado

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Salvar a apresentação

  p.Save("Output.pptx", SaveFormat.Pptx);

}
``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para mais detalhes, visite [Aplicar ou Alterar Layouts de Slide no .NET](/slides/pt/net/slide-layout/).
{{% /alert %}}