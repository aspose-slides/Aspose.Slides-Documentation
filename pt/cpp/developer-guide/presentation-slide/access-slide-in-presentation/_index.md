---
title: Acessar slides de apresentação em C++
linktitle: Acessar slide
type: docs
weight: 20
url: /pt/cpp/access-slide-in-presentation/
keywords:
- acessar slide
- índice do slide
- id do slide
- posição do slide
- alterar posição
- propriedades do slide
- número do slide
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Saiba como acessar e gerenciar slides em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++. Aumente a produtividade com exemplos de código."
---
## **Visão geral**

Este artigo explica como acessar e gerenciar slides em uma apresentação usando Aspose.Slides. Ele mostra como recuperar slides pelo seu índice baseado em zero a partir da coleção de slides e como acessar um slide pelo seu ID exclusivo usando o método `GetSlideById`.

Você também aprenderá como alterar a posição de um slide usando o método `set_SlideNumber` e como definir o número do slide inicial de uma apresentação com o método `set_FirstSlideNumber`. Os exemplos demonstram o carregamento de uma apresentação, a obtenção de referências de slides, a atualização da ordem ou numeração dos slides e a gravação da apresentação modificada.

## **Acessar um slide por índice**

Todos os slides em uma apresentação são organizados numericamente com base na posição do slide, começando em 0. O primeiro slide é acessível através do índice 0; o segundo slide é acessado através do índice 1; etc.

A classe Presentation, que representa um arquivo de apresentação, expõe todos os slides como uma coleção [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/) (coleção de objetos [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/)). Este código C++ mostra como acessar um slide pelo seu índice:

```c++
	// O caminho para o diretório de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia a classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtém a referência de um slide através do seu índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Acessar um slide por ID**

Cada slide em uma apresentação tem um ID exclusivo associado a ele. Você pode usar o método [GetSlideById()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/getslidebyid/) (exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/)) para direcionar esse ID. Este código C++ mostra como fornecer um ID de slide válido e acessar esse slide através do método [GetSlideById()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// O caminho para o diretório de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia a classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtém o ID de um slide
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Acessa o slide através do seu ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Alterar a posição do slide**

Aspose.Slides permite que você altere a posição de um slide. Por exemplo, você pode especificar que o primeiro slide passe a ser o segundo slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha a referência do slide (cuja posição você deseja mudar) através do seu índice.
1. Defina uma nova posição para o slide através da propriedade [set_SlideNumber()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/set_slidenumber/).
1. Salve a apresentação modificada.

Este código C++ demonstra uma operação em que o slide na posição 1 é movido para a posição 2:

```c++
	// O caminho para o diretório de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instancia a classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtém o slide cuja posição será alterada
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Define a nova posição para o slide
	slide->set_SlideNumber(2);

	// Salva a apresentação modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

O primeiro slide tornou‑se o segundo; o segundo slide tornou‑se o primeiro. Quando você muda a posição de um slide, os demais slides são ajustados automaticamente.

## **Definir o número do slide**

Usando a propriedade [set_FirstSlideNumber()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/set_firstslidenumber/) (exposta pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/)), você pode especificar um novo número para o primeiro slide de uma apresentação. Essa operação faz com que os demais números de slide sejam recalculados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha o número do slide.
1. Defina o número do slide.
1. Salve a apresentação modificada.

Este código C++ demonstra uma operação onde o número do primeiro slide é definido como 10:

```c++
	// O caminho para o diretório de documentos.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instancia a classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtém o número do slide
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Define o número do slide
	pres->set_FirstSlideNumber(2);
	
	// Salva a apresentação modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Se preferir pular o primeiro slide, você pode iniciar a numeração a partir do segundo slide (e ocultar a numeração do primeiro slide) da seguinte forma:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Define o número para o primeiro slide da apresentação
presentation->set_FirstSlideNumber(0);

// Exibe os números dos slides para todos os slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Oculta o número do slide para o primeiro slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Salva a apresentação modificada
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**O número do slide que o usuário vê corresponde ao índice baseado em zero da coleção?**

O número exibido em um slide pode começar a partir de um valor arbitrário (por exemplo, 10) e não precisa coincidir com o índice; o relacionamento é controlado pela configuração de [first slide number](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/set_firstslidenumber/) da apresentação.

**Slides ocultos afetam a indexação?**

Sim. Um slide oculto permanece na coleção e é contado na indexação; “oculto” refere‑se à exibição, não à sua posição na coleção.

**O índice de um slide muda quando outros slides são adicionados ou removidos?**

Sim. Os índices sempre refletem a ordem atual dos slides e são recalculados ao inserir, excluir ou mover slides.