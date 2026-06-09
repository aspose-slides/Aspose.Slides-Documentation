---
title: Renderizado como TIFF com Dimensão Definida pelo Usuário
type: docs
weight: 40
url: /pt/net/rendered-as-tiff-by-user-defined-dimension/
---
O exemplo a seguir demonstra como converter uma apresentação em documento TIFF com tamanho de imagem personalizado usando a classe **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation(srcFileName);

//Instanciar a classe TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Definindo o tipo de compressão
opts.CompressionType = TiffCompressionTypes.Default;

//Tipos de compressão
//Default - Especifica o esquema de compressão padrão (LZW).
//None - Especifica nenhuma compressão.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - depende do tipo de compressão e não pode ser definido manualmente.
//Resolution unit - é sempre igual a "2" (pontos por polegada)
//Definindo DPI da imagem
opts.DpiX = 200;
opts.DpiY = 100;

//Definir tamanho da imagem
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)