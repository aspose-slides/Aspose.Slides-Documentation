---
title: Formatar Texto
type: docs
weight: 110
url: /pt/net/format-text/
---
Tanto os métodos VSTO quanto os do Aspose.Slides seguem as etapas a seguir:

- Abra a apresentação de origem.
- Acesse o primeiro slide.
- Acesse a terceira caixa de texto.
- Altere a formatação do texto na terceira caixa de texto.
- Salve a apresentação no disco.
## **VSTO**
``` csharp

 //Abrir a apresentação
Presentation pres = new Presentation("source.ppt");

//Adicionar fonte Verdana
FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Acessar o primeiro slide
Slide slide = pres.GetSlideByPosition(1);

//Acessar a terceira forma
Shape shp = slide.Shapes[2];

//Alterar a fonte do texto para Verdana e altura para 32
TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Deixar em negrito
port.FontBold = true;

//Deixar em itálico
port.FontItalic = true;

//Alterar a cor do texto
port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Alterar a cor de fundo da forma
shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Gravar a saída no disco
pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Abrir a apresentação
pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Acessar o primeiro slide
PowerPoint.Slide slide = pres.Slides[1];

//Acessar a terceira forma
PowerPoint.Shape shp = slide.Shapes[3];

//Alterar a fonte do texto para Verdana e altura para 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Deixar em negrito
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Deixar em itálico
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Alterar a cor do texto
txtRange.Font.Color.RGB = 0x00CC3333;

//Alterar a cor de fundo da forma
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposicionar horizontalmente
shp.Left -= 70;

//Gravar a saída no disco
pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)