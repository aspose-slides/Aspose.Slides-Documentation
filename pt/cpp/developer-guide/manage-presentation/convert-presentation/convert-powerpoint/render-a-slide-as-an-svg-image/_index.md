---
title: Renderizar slides de apresentação como imagens SVG em C++
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint para SVG
- apresentação para SVG
- slide para SVG
- PPT para SVG
- PPTX para SVG
- opções de exportação SVG
- SVG interativo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Exporte slides do PowerPoint como imagens SVG em C++ e controle fontes, texto, imagens, IDs e eventos com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides for C++ exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/) quando o SVG exportado precisar ser compacto, previsível entre navegadores ou pronto para uso interativo.

## **Exportar um slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), selecione um slide e grave-o em um fluxo. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

O nome do arquivo usa [ISlide::get_SlideNumber](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/get_slidenumber/) em vez do índice do loop. Você também pode exportar uma forma individual com [IShape::WriteAsSvg](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/writeassvg/) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar a saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/) controla a renderização do SVG. Para quadros de texto, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_useframesize/) inclui o quadro de texto na área de renderização, e [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) como `true` quando o texto precisar ser renderizado sem ligaduras.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Controlar texto e fontes**

### **Vectorizar todo o texto**

Defina [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) como `true` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, porém o texto deixa de ser selecionável ou pesquisável como texto SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Escolher como as fontes externas são manipuladas**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `AddLinksToFontFiles` para referenciar arquivos de fonte separados, `Embed` para incluir os dados da fonte no SVG ou `Vectorize` para renderizar como gráficos apenas o texto que usa fontes externas. Verifique a licença das fontes antes de incorporá‑las.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Reduzir o tamanho de imagens incorporadas**

Use [SVGOptions::set_PpicturesCompression](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_picturescompression/) para reduzir a resolução das imagens incorporadas, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) para omitir áreas de origem recortadas e [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_jpegquality/) para controlar a qualidade da codificação JPEG. Essas configurações diminuem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados de imagem retidos.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Atribuir IDs estáveis a formas e texto**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshapeformattingcontroller/) para definir [ISvgShape::set_Id](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshape/set_id/) para cada forma SVG. Para definir valores [ISvgTSpan::set_Id](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgtspan/set_id/) em elementos `tspan` de texto também, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Atribua qualquer um dos controladores com [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

O controlador a seguir usa [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_officeinteropshapeid/), que é estável durante a vida útil da forma, e um contador repetível para seus trechos de texto. Isso torna os IDs gerados adequados para pós‑processamento de uma apresentação que não foi alterada.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Adicionar manipuladores de eventos SVG**

Em um [ISvgShapeFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshapeformattingcontroller/), chame [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshape/seteventhandler/) com um valor [SvgEvent](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgevent/) para adicionar um manipulador de evento JavaScript a uma forma exportada. Atribua o controlador com [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) e defina a função JavaScript na página ou documento SVG que hospeda o resultado.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

A página host pode definir a função JavaScript referenciada pelo manipulador. Atribuir IDs e manipuladores de eventos habilita visualizadores de slides, aprimoramentos de acessibilidade e outros fluxos de trabalho interativos com SVG.

## **FAQ**

**Quando devo usar [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) em vez de [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgexternalfontshandling/) quando somente o texto que utiliza fontes externas deve ser convertido em gráficos.

**Qual a melhor maneira de tornar um SVG menor?**

Comece comprimindo imagens incorporadas, excluindo áreas de imagem recortadas e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder fornecê‑los. Teste o resultado, pois redução de resolução da imagem, qualidade JPEG mais baixa e texto vetorizado têm impactos diferentes na qualidade e no tamanho.

**Posso modificar os elementos SVG exportados após a exportação?**

Sim. Atribua IDs por meio de um controlador de formatação e, em seguida, selecione os elementos SVG correspondentes na sua ferramenta de pós‑processamento ou script de navegador.