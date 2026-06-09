---
title: Incorporar fontes em apresentações em .NET
linktitle: Incorporar Fonte
type: docs
weight: 40
url: /pt/net/embedded-font/
keywords:
- adicionar fonte
- incorporar fonte
- incorporação de fonte
- obter fonte incorporada
- adicionar fonte incorporada
- remover fonte incorporada
- compactar fonte incorporada
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para .NET, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Incorporar fontes no PowerPoint** garante que sua apresentação mantenha a aparência pretendida em diferentes sistemas. Seja usando fontes exclusivas para criatividade ou as padrão, incorporar fontes evita interrupções de texto e layout.

Se você usou uma fonte de terceiros ou não padrão porque foi criativo com seu trabalho, então tem ainda mais motivos para incorporar sua fonte. Caso contrário (sem fontes incorporadas), os textos ou números em seus slides, o layout, a estilização, etc., podem mudar ou se transformar em retângulos confusos. 

Utilize as classes [FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/pt/net/aspose.slides/fontdata/) e [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/) para gerenciar fontes incorporadas.

## **Obter e Remover Fontes Incorporadas**

Recupere ou remova fontes incorporadas de uma apresentação facilmente com os métodos [GetEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getembeddedfonts) e [RemoveEmbeddedFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/removeembeddedfont).

Este código C# mostra como obter e remover fontes incorporadas de uma apresentação:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderiza um slide contendo um quadro de texto que usa a fonte "FunSized" incorporada
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Encontra a fonte "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Remove a fonte "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renderiza a apresentação; a fonte "Calibri" é substituída por uma existente
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Salva a apresentação sem a fonte "Calibri" incorporada no disco
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Adicionar Fontes Incorporadas**

Usando o enum [EmbedFontCharacters](https://reference.aspose.com/slides/pt/net/aspose.slides.export/embedfontcharacters/) e duas sobrecargas do método [AddEmbeddedFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/addembeddedfont/), você pode selecionar a regra de (incorporação) preferida para incorporar as fontes em uma apresentação. Este código C# mostra como incorporar e adicionar fontes a uma apresentação:

```c#
// Carrega a apresentação
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Salva a apresentação no disco
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Comprimir Fontes Incorporadas**

Otimize o tamanho do arquivo comprimindo fontes incorporadas usando [CompressEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Exemplo de código para compressão:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Perguntas Frequentes**

**Como posso saber se uma fonte específica na apresentação ainda será substituída durante a renderização, apesar de estar incorporada?**

Verifique as [informações de substituição](/slides/pt/net/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/net/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes "sistema" como Arial/Calibri?**

Normalmente não - elas estão quase sempre disponíveis. Mas para total portabilidade em ambientes "thin" (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.