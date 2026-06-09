---
title: Conversão de Documento OpenOffice
type: docs
weight: 30
url: /pt/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET oferece a classe **Presentation** que representa um arquivo de apresentação. A classe **Presentation** agora também pode acessar **ODP** através do construtor Presentation quando o objeto é instanciado.

Abaixo está o exemplo de conversão de ODP para PPT/PPTX.
## **Exemplo**
```

 //Instanciar um objeto Presentation que representa um arquivo de apresentação

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{
   //Salvar a apresentação PPTX no formato PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}
``` 

Abaixo está o exemplo de conversão de PPT/PPTX para ODP.
## **Exemplo**
``` 

 //Instanciar um objeto Presentation que representa um arquivo de apresentação

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Salvar a apresentação PPTX no formato PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)