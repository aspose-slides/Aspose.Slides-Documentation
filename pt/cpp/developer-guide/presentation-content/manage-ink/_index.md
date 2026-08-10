---
title: Gerenciar objetos de tinta de apresentação em C++
linktitle: Gerenciar Tinta
type: docs
weight: 95
url: /pt/cpp/manage-ink/
keywords:
- tinta
- objeto de tinta
- traço de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- exportação de tinta
- renderização de tinta
- ocultar tinta
- IInkOptions
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint, edite rastros e propriedades de pincel, e controle a aparência da tinta durante a exportação para PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para C++."
---
## **Introdução**

O PowerPoint oferece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para destacar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide.

O namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/) contém as classes e interfaces necessárias para trabalhar com objetos de tinta. Por exemplo, a interface [IInk](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Normais e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Na sua forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) juntamente com propriedades como o tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/cpp/shape-manipulations/#access-layout-formats-for-shape).

No entanto, quando o PowerPoint manipula um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos métodos padrão [IShape::get_Width](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_width/) e [IShape::get_Height](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Tinta**

Um traço de tinta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de tinta. O pincel tem sua própria cor e tamanho, representados pelos métodos [IInkBrush::get_Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iinkbrush/get_color/) e [IInkBrush::get_Size](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Definir Cor do Pincel de Tinta**

Este código C++ mostra como definir a cor de um pincel de tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Definir Tamanho do Pincel de Tinta**

Este código C++ mostra como definir o tamanho de um pincel de tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Geralmente, a largura e a altura de um pincel não coincidem, de modo que o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente fica em cinza). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, deve‑se levar em conta o tamanho do pincel dos seus traços. Aqui, o objeto alvo (o traço de texto manuscrito) foi dimensionado ao tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta durante a Exportação e Renderização**

Aspose.Slides fornece a interface [IInkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar seus métodos para ocultar totalmente a tinta ou mudar como as operações de máscara do pincel de tinta são interpretadas.

As opções de tinta estão disponíveis através das opções de exportação ou renderização para vários tipos de saída:

| Saída | Método de opções de tinta |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Imagem do slide | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Os mesmos dois parâmetros estão disponíveis através desses métodos:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_hideink/) determina se os objetos de tinta são incluídos na saída. Seu valor padrão é `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `true`; defina como `false` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Chame [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_hideink/) com `true` quando precisar de uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta.

O exemplo C++ a seguir exporta uma apresentação para PDF ocultando todos os objetos de tinta:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) e passe as opções de renderização ao método [ISlide::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/).

O exemplo C++ a seguir renderiza o primeiro slide como imagem PNG sem objetos de tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Controlar a Renderização da Máscara de Tinta**

O método [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `true`, que usa opacidade. Chame o método com `false` para usar a operação ROP em vez disso.

O exemplo C++ a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

O mesmo ajuste pode ser aplicado através de [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher entre Ocultar ou Preservar a Tinta**

Use [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_hideink/) com `true` quando o arquivo exportado deve ser uma versão limpa de uma apresentação anotada, por exemplo, uma cópia final destinada à distribuição sem marcas de revisão.

Deixe a tinta visível (a configuração padrão `false`) quando as anotações de tinta fazem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e final separadas a partir da mesma apresentação sem modificar os objetos de tinta originais.

## **FAQ**

**Posso alterar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtenha o traço através de [IInk::get_Traces](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iink/get_traces/), então altere seu [IInkTrace::get_Brush](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iinktrace/get_brush/). Você pode chamar [IInkBrush::set_Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iinkbrush/set_color/) e [IInkBrush::set_Size](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/iinkbrush/set_size/) no pincel.

**Ocultar a tinta altera a apresentação original?**

Não. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/iinkoptions/set_hideink/) afeta apenas o resultado renderizado ou exportado; ele não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides através das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/cpp/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/cpp/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pt/cpp/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pt/cpp/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pt/cpp/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pt/cpp/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pt/cpp/convert-slide/).