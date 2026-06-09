---
title: Incorporar fontes em apresentações usando C++
linktitle: Incorporação de fonte
type: docs
weight: 40
url: /pt/cpp/embedded-font/
keywords:
- adicionar fonte
- incorporar fonte
- incorporação de fonte
- obter fonte incorporada
- adicionar fonte incorporada
- remover fonte incorporada
- comprimir fonte incorporada
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Fontes incorporadas no PowerPoint** ajudam a garantir que sua apresentação mantenha sua aparência pretendida quando aberta em qualquer sistema ou dispositivo. Isso é especialmente importante ao usar fontes personalizadas, de terceiros ou não‑padrão para branding ou fins criativos. Sem fontes incorporadas, o texto pode ser substituído, os layouts podem quebrar e os caracteres podem aparecer como símbolos ilegíveis ou retângulos, comprometendo o design geral.

Aspose.Slides for C++ fornece um conjunto de APIs poderosas para gerenciar fontes incorporadas programaticamente. Você pode usar as classes [FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/) e [FontData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontdata/) para inspecionar, adicionar ou remover fontes incorporadas nos arquivos de sua apresentação. Além disso, a classe [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/) permite otimizar o tamanho do arquivo comprimindo os dados das fontes sem afetar a qualidade ou a aparência.

Essas ferramentas dão a você controle total sobre a incorporação de fontes, ajudando a manter tipografia consistente entre plataformas enquanto reduz o tamanho do arquivo quando necessário.

## **Obter fontes incorporadas de uma apresentação**

Aspose.Slides for C++ fornece o método `GetEmbeddedFonts` através da classe [FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/), que permite recuperar uma lista de fontes incorporadas em uma apresentação PowerPoint. Isso pode ser útil para auditoria do uso de fontes, garantir conformidade com diretrizes de branding ou verificar se todas as fontes necessárias estão incluídas corretamente antes de compartilhar o arquivo.

O código C++ a seguir demonstra como obter fontes incorporadas de um arquivo de apresentação:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Obter todas as fontes incorporadas.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Imprimir nomes das fontes incorporadas.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Adicionar fontes incorporadas a uma apresentação**

Aspose.Slides for C++ permite incorporar fontes em uma apresentação PowerPoint usando o método [AddEmbeddedFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/addembeddedfont/), que possui duas sobrecargas para uso flexível. Você pode controlar a quantidade de fonte que é incorporada usando a enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/embedfontcharacters/), por exemplo, escolhendo incorporar apenas os caracteres usados ou todo o conjunto de fontes. Esse recurso é especialmente útil ao preparar uma apresentação para compartilhamento ou distribuição, garantindo que fontes personalizadas ou não‑padrão apareçam corretamente em todos os sistemas, mesmo que essas fontes não estejam instaladas.

O código C++ a seguir verifica todas as fontes usadas em uma apresentação e incorpora quaisquer fontes que ainda não estejam incorporadas.

```cpp
// Carregar um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Verificar se a fonte já está incorporada.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Incorporar a fonte na apresentação.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Salvar a apresentação no disco.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remover fontes incorporadas de uma apresentação**

Aspose.Slides for C++ fornece o método `RemoveEmbeddedFont` através da classe [FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/), que permite remover fontes específicas incorporadas em uma apresentação PowerPoint. Isso pode ajudar a reduzir o tamanho geral do arquivo, especialmente se as fontes incorporadas não são mais usadas ou necessárias. Remover fontes não utilizadas também pode melhorar o desempenho e garantir que sua apresentação inclua apenas recursos essenciais.

O código C++ a seguir demonstra como remover uma fonte incorporada de uma apresentação:

```cpp
auto fontName = u"Calibri";

// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Obter todas as fontes incorporadas.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Remover a fonte incorporada.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Comprimir fontes incorporadas**

Aspose.Slides for C++ fornece o método `CompressEmbeddedFonts` através da classe [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/), permitindo reduzir o tamanho geral de uma apresentação otimizando os dados das fontes incorporadas. Isso é especialmente útil quando sua apresentação inclui fontes grandes ou múltiplas, e você deseja manter o arquivo leve para compartilhamento, armazenamento ou uso online — sem comprometer a fidelidade visual do conteúdo.

O código C++ a seguir demonstra como comprimir fontes incorporadas em uma apresentação PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

**Como posso saber se uma fonte específica na apresentação ainda será substituída durante a renderização, apesar da incorporação?**

Verifique as [informações de substituição](/slides/pt/cpp/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/cpp/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes "do sistema" como Arial/Calibri?**

Normalmente não — elas estão quase sempre disponíveis. Mas para total portabilidade em ambientes “delgados” (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.