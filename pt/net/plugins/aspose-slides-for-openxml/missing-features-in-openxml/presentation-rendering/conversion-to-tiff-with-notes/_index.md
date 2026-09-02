---
title: Conversão para Tiff com Notas
type: docs
weight: 10
url: /pt/net/conversion-to-tiff-with-notes/
---
TIFF é um dos vários formatos de imagem amplamente utilizados que o Aspose.Slides para .NET oferece suporte para converter uma apresentação com notas em imagens. Você também pode gerar miniaturas de slides na visualização de Slides de Notas. A seguir, há dois trechos de código que mostram como gerar imagens TIFF de uma apresentação na visualização de Slides de Notas.

O método **Save** exposto pela classe **Presentation** pode ser usado para converter toda a apresentação na visualização de Slides de Notas para TIFF. Você também pode gerar uma miniatura de slide na visualização de Slides de Notas para slides individuais.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instanciar um objeto Presentation que representa um arquivo de apresentação
using (Presentation pres = new Presentation(srcFileName))
{
    //Colocar as notas do orador abaixo de cada slide renderizado
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Salvar a apresentação em TIFF com notas
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Baixar código de exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)