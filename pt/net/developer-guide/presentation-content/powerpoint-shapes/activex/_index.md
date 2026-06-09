---
title: Gerenciar Controles ActiveX em Apresentações no .NET
linktitle: ActiveX
type: docs
weight: 80
url: /pt/net/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- player de mídia
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como o Aspose.Slides for .NET utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, oferecendo aos desenvolvedores controle poderoso sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. Aspose.Slides for .NET permite que você gerencie controles ActiveX, mas administrá‑los é um pouco mais complicado e diferente dos shapes normais de apresentação. A partir do Aspose.Slides for .NET 6.9.0, o componente oferece suporte ao gerenciamento de controles ActiveX. No momento, você pode acessar um controle ActiveX já adicionado na sua apresentação e modificá‑lo ou excluí‑lo usando suas diversas propriedades. Lembre‑se de que os controles ActiveX não são shapes e não fazem parte da IShapeCollection da apresentação, mas da IControlCollection separada. Este artigo mostra como trabalhar com eles.
## **Modificar controles ActiveX**
Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide:

1. Crie uma instância da classe Presentation e carregue a apresentação com controles ActiveX nela.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse os controles ActiveX no slide acessando a IControlCollection.
1. Acesse o controle ActiveX TextBox1 usando o objeto ControlEx.
1. Altere as diferentes propriedades do controle ActiveX TextBox1, incluindo texto, fonte, altura da fonte e posição da moldura.
1. Acesse o segundo controle chamado CommandButton1.
1. Altere a legenda do botão, a fonte e a posição.
1. Desloque a posição das molduras dos controles ActiveX.
1. Grave a apresentação modificada em um arquivo PPTX.

O trecho de código abaixo atualiza os controles ActiveX nos slides da apresentação conforme mostrado abaixo.

```c#
// Acessando a apresentação com controles ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Acessando o primeiro slide na apresentação
ISlide slide = presentation.Slides[0];

// alterando o texto da TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // alterando a imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX, então às vezes é aceitável deixar a imagem inalterada.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// alterando a legenda do botão
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // alterando a imagem substituta
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Movendo as molduras ActiveX 100 pontos para baixo
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Salvar a apresentação com controles ActiveX editados
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Agora removendo os controles
slide.Controls.Clear();

// Salvando a apresentação com controles ActiveX removidos
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Adicionar um controle ActiveX Media Player**
Para adicionar o controle ActiveX Media Player, siga as etapas a seguir:

1. Crie uma instância da classe Presentation e carregue a apresentação de exemplo com controles ActiveX Media Player nela.
1. Crie uma instância da classe Presentation de destino e gere uma instância de apresentação vazia.
1. Clone o slide com o controle ActiveX Media Player na apresentação modelo para a Presentation de destino.
1. Acesse o slide clonado na Presentation de destino.
1. Acesse os controles ActiveX no slide acessando a IControlCollection.
1. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
1. Salve a apresentação em um arquivo PPTX.

```c#
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation presentation = new Presentation("template.pptx");

// Criar uma instância vazia de apresentação
Presentation newPresentation = new Presentation();

// Remover o slide padrão
newPresentation.Slides.RemoveAt(0);

// Clonar o slide com o controle ActiveX Media Player
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Acessar o controle ActiveX Media Player e definir o caminho do vídeo
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Salvar a apresentação
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**O Aspose.Slides preserva os controles ActiveX ao ler e salvar novamente se eles não puderem ser executados no runtime .NET?**

Sim. O Aspose.Slides trata‑os como parte da apresentação e pode ler/modificar suas propriedades e molduras; não é necessário executar os controles para preservá‑‑los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, player de mídia), enquanto [OLE](/slides/pt/net/manage-ole/) refere‑se a objetos de aplicação incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; porém, eventos e macros são executados somente dentro do PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.