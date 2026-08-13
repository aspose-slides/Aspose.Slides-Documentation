---
title: Mescle apresentações de forma eficiente em C++
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/cpp/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Mescle apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) de forma fácil com Aspose.Slides para C++, simplificando seu fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite mesclar apresentações clonando slides de uma apresentação para outra. Este artigo explica como mesclar apresentações completas ou slides selecionados, usar um mestre de slides ou um layout específico durante a mesclagem, lidar com apresentações com diferentes tamanhos de slide e adicionar slides mesclados a uma seção de apresentação. Também aborda notas práticas relacionadas ao conteúdo mesclado, incluindo notas do apresentador, comentários, arquivos de origem protegidos por senha e uso de threads.

## **Mesclagem de Apresentações**

Quando você mescla uma apresentação a outra, está efetivamente combinando seus slides em uma única apresentação para obter um único arquivo.

{{% alert title="Info" color="info" %}}

A maioria dos programas de apresentação (PowerPoint ou OpenOffice) não possui funções que permitam aos usuários combinar apresentações dessa forma. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/pt/cpp/), no entanto, permite mesclar apresentações de diferentes maneiras. Você pode mesclar apresentações com todas as suas formas, estilos, textos, formatação, comentários, animações, etc., sem se preocupar com perda de qualidade ou dados. 

**Veja também**

[Clonar Slides](https://docs.aspose.com/slides/pt/cpp/clone-slides/)*.* 

{{% /alert %}}

### **O que pode ser mesclado**

* apresentações completas. Todos os slides das apresentações acabam em uma única apresentação
* slides específicos. Slides selecionados acabam em uma única apresentação
* apresentações em um único formato (PPT para PPT, PPTX para PPTX, etc.) e em formatos diferentes (PPT para PPTX, PPTX para ODP, etc.) entre si. 

{{% alert title="Note" color="warning" %}} 

Além de apresentações, Aspose.Slides permite mesclar outros arquivos:

* [Imagens](https://products.aspose.com/slides/pt/cpp/merger/image-to-image/), como [JPG para JPG](https://products.aspose.com/slides/pt/cpp/merger/jpg-to-jpg/) ou [PNG para PNG](https://products.aspose.com/slides/pt/cpp/merger/png-to-png/)
* Documentos, como [PDF para PDF](https://products.aspose.com/slides/pt/cpp/merger/pdf-to-pdf/) ou [HTML para HTML](https://products.aspose.com/slides/pt/cpp/merger/html-to-html/)
* E dois tipos diferentes de arquivos, como [imagem para PDF](https://products.aspose.com/slides/pt/cpp/merger/image-to-pdf/), [JPG para PDF](https://products.aspose.com/slides/pt/cpp/merger/jpg-to-pdf/) ou [TIFF para PDF](https://products.aspose.com/slides/pt/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opções de Mesclagem**

Você pode aplicar opções que determinam se

* cada slide na apresentação de saída mantém um estilo exclusivo
* um estilo específico é usado para todos os slides na apresentação de saída. 

Para mesclar apresentações, Aspose.Slides fornece os métodos [AddClone](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (da interface [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection)). Existem várias implementações dos métodos `AddClone` que definem os parâmetros do processo de mesclagem de apresentações. Cada objeto Presentation possui uma coleção [Slides](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), de modo que você pode chamar um método `AddClone` a partir da apresentação na qual deseja mesclar os slides. 

O método `AddClone` devolve um objeto `ISlide`, que é um clone do slide de origem. Os slides em uma apresentação de saída são simplesmente uma cópia dos slides da origem. Portanto, você pode fazer alterações nos slides resultantes (por exemplo, aplicar estilos ou opções de formatação ou layouts) sem se preocupar em afetar as apresentações de origem. 

## **Mesclar Apresentações** 

Aspose.Slides fornece o método [**AddClone (ISlide)**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) que permite combinar slides mantendo seus layouts e estilos (parâmetros padrão). 

Este código C++ mostra como mesclar apresentações:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar Apresentações com um Mestre de Slides**

Aspose.Slides fornece o método [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) que permite combinar slides aplicando um modelo de mestre de slides à apresentação. Dessa forma, se necessário, você pode alterar o estilo dos slides na apresentação de saída. 

Este código C++ demonstra a operação descrita:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

O layout do slide para o mestre de slides é determinado automaticamente. Quando um layout apropriado não pode ser determinado, se o parâmetro booleano `allowCloneMissingLayout` do método `AddClone` estiver definido como true, o layout do slide de origem será usado. Caso contrário, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Se você quiser que os slides na apresentação de saída tenham um layout de slide diferente, use o método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) em vez disso ao mesclar. 

## **Mesclar Slides Específicos de Apresentações**

Mesclar slides específicos de várias apresentações é útil para criar decks de slides personalizados. Aspose.Slides C++ permite selecionar e importar somente os slides necessários. A API preserva a formatação, o layout e o design dos slides originais.

O código C++ a seguir cria uma nova apresentação, adiciona slides de título de duas outras apresentações e salva o resultado em um arquivo:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Declarado no código acima.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Mesclar Apresentações com um Layout de Slide**

Este código C++ mostra como combinar slides de apresentações aplicando o layout de slide desejado a eles para obter uma única apresentação de saída:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar Apresentações com Tamanhos de Slide Diferentes**

{{% alert title="Note" color="warning" %}} 

Você não pode mesclar apresentações com tamanhos de slide diferentes. 

{{% /alert %}}

Para mesclar 2 apresentações com tamanhos de slide diferentes, é necessário redimensionar uma das apresentações para que seu tamanho corresponda ao da outra apresentação. 

Este código de exemplo demonstra a operação descrita:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar Slides a uma Seção de Apresentação**

Este código C++ mostra como mesclar um slide específico a uma seção em uma apresentação:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

O slide é adicionado no final da seção. 

{{% alert title="Tip" color="info" %}}

A Aspose oferece um [aplicativo web GRATUITO Collage](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar [JPG para JPG](https://products.aspose.app/slides/pt/collage/jpg) ou imagens PNG para PNG, criar [grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid) e assim por diante. 

{{% /alert %}}

## **FAQ**

### As notas do apresentador são preservadas durante a mesclagem?

Sim. Ao clonar slides, Aspose.Slides transfere todos os elementos do slide, incluindo notas, formatação e animações.

### Comentários e seus autores são transferidos?

Os comentários, como parte do conteúdo do slide, são copiados junto com o slide. Os rótulos de autor dos comentários são preservados como objetos de comentário na apresentação resultante.

### E se a apresentação de origem estiver protegida por senha?

Ela deve ser [aberta com a senha](/slides/pt/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/); após o carregamento, esses slides podem ser clonados com segurança para um arquivo de destino não protegido (ou também protegido).

### Quão thread‑safe é a operação de mesclagem?

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) a partir de [várias threads](/slides/pt/cpp/multithreading/). A regra recomendada é “um documento — uma thread”; arquivos diferentes podem ser processados em paralelo em threads distintas.