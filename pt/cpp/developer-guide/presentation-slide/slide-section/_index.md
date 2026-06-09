---
title: Gerenciar Seções de Slides em Apresentações Usando C++
linktitle: Seção de Slides
type: docs
weight: 100
url: /pt/cpp/slide-section/
keywords:
- criar seção
- adicionar seção
- editar seção
- alterar seção
- nome da seção
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Simplifique as seções de slides no PowerPoint e OpenDocument com Aspose.Slides para C++ — divida, renomeie e reorganize para otimizar fluxos de trabalho PPTX e ODP."
---
## **Introdução**

Com o Aspose.Slides para C++, você pode organizar uma apresentação do PowerPoint em seções. Você pode criar seções que contêm slides específicos.

Você pode querer criar seções e usá‑las para organizar ou dividir os slides de uma apresentação em partes lógicas nas seguintes situações:

- Quando você está trabalhando em uma apresentação grande com outras pessoas ou uma equipe — e precisa atribuir determinados slides a um colega ou a alguns membros da equipe. 
- Quando você está lidando com uma apresentação que contém muitos slides — e está tendo dificuldade em gerenciar ou editar seu conteúdo de uma só vez.

Idealmente, você deve criar uma seção que agrupe slides semelhantes — os slides têm algo em comum ou podem existir em um grupo baseado em uma regra — e dar à seção um nome que descreva os slides contidos nela.

## **Criar Seções em Apresentações**

Para adicionar uma seção que agrupará slides em uma apresentação, o Aspose.Slides para C++ fornece o método AddSection, que permite especificar o nome da seção que você pretende criar e o slide a partir do qual a seção começa.

Este exemplo de código mostra como criar uma seção em uma apresentação em C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 será finalizada em newSlide2 e, depois, section2 começará

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Alterar os Nomes das Seções**

Depois de criar uma seção em uma apresentação do PowerPoint, você pode decidir alterar seu nome.

Este exemplo de código mostra como alterar o nome de uma seção em uma apresentação em C++ usando o Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

Não. O formato PPT não oferece suporte a metadados de seção, portanto o agrupamento de seções é perdido ao salvar em .ppt.

**Uma seção inteira pode ser "oculta"?**

Não. Apenas slides individuais podem ser ocultados. Uma seção, como entidade, não possui estado "oculto".

**Posso localizar rapidamente uma seção a partir de um slide e, inversamente, o primeiro slide de uma seção?**

Sim. Uma seção é definida de forma única pelo seu slide inicial; dado um slide, você pode determinar a que seção ele pertence, e para uma seção você pode acessar seu primeiro slide.