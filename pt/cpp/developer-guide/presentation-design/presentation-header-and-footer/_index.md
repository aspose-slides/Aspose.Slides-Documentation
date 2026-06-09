---
title: Gerenciar cabeçalhos e rodapés de apresentação em C++
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/cpp/presentation-header-and-footer/
keywords:
- cabeçalho
- texto do cabeçalho
- rodapé
- texto do rodapé
- definir cabeçalho
- definir rodapé
- folheto
- notas
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Use o Aspose.Slides para C++ para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument, proporcionando um visual profissional."
---
## **Visão geral**

Aspose.Slides permite gerenciar as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são manipulados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides mestres de notas.

Você também pode gerenciar cabeçalhos e rodapés para slides de folhetos e notas. Isso inclui alterar a visibilidade e o texto dos marcadores de posição de cabeçalho, rodapé, número do slide e data/hora para o mestre de notas, todos os slides de notas filhos ou um slide de notas individual.

## **Gerenciar texto de cabeçalho e rodapé**

As notas de um slide específico podem ser atualizadas como mostrado no exemplo abaixo:

``` cpp
// Função para definir o texto do cabeçalho/rodapé
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Carregar apresentação
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Definir rodapé
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Acessar e atualizar cabeçalho
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Salvar apresentação
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Gerenciar cabeçalhos e rodapés em folhetos e slides de notas**
Aspose.Slides for C++ oferece suporte a Cabeçalho e Rodapé em slides de folhetos e notas. Siga as etapas abaixo:

- Carregue uma [Presentation ](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) contendo um vídeo.
- Altere as configurações de cabeçalho e rodapé para o mestre de notas e todos os slides de notas.
- Defina o slide mestre de notas e todos os marcadores de posição de rodapé filhos como visíveis.
- Defina o slide mestre de notas e todos os marcadores de posição de data e hora filhos como visíveis.
- Altere as configurações de cabeçalho e rodapé apenas para o primeiro slide de notas.
- Defina o marcador de posição de cabeçalho do slide de notas como visível.
- Defina o texto do marcador de posição de cabeçalho do slide de notas.
- Defina o texto do marcador de posição de data e hora do slide de notas.
- Grave o arquivo de apresentação modificado.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Alterar as configurações de cabeçalho e rodapé para o mestre de notas e todos os slides de notas
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// torne o slide mestre de notas e todos os marcadores de posição de rodapé filhos visíveis
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// torne o slide mestre de notas e todos os marcadores de posição de cabeçalho filhos visíveis
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// torne o slide mestre de notas e todos os marcadores de posição de número do slide filhos visíveis
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// torne o slide mestre de notas e todos os marcadores de posição de data e hora filhos visíveis
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// defina o texto no slide mestre de notas e em todos os marcadores de posição de cabeçalho filhos
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// defina o texto no slide mestre de notas e em todos os marcadores de posição de rodapé filhos
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// defina o texto no slide mestre de notas e em todos os marcadores de posição de data e hora filhos
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Alterar as configurações de cabeçalho e rodapé apenas para o primeiro slide de notas
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// torne este marcador de posição de cabeçalho do slide de notas visível
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// torne este marcador de posição de rodapé do slide de notas visível
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// torne este marcador de posição de número do slide do slide de notas visível
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// torne este marcador de posição de data e hora do slide de notas visível
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// defina o texto no marcador de posição de cabeçalho do slide de notas
	headerFooterManager->SetHeaderText(u"New header text");
	// defina o texto no marcador de posição de rodapé do slide de notas
	headerFooterManager->SetFooterText(u"New footer text");
	// defina o texto no marcador de posição de data e hora do slide de notas
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **Perguntas frequentes**

**Posso adicionar um "cabeçalho" aos slides normais?**

No PowerPoint, o "cabeçalho" existe apenas para notas e folhetos; nos slides normais, os elementos suportados são rodapé, data/hora e número do slide. No Aspose.Slides isso segue as mesmas limitações: cabeçalho apenas para Notas/Folhetos e, nos slides, Rodapé/DataHora/NúmeroDoSlide.

**E se o layout não contiver uma área de rodapé—posso "ativar" sua visibilidade?**

Sim. Verifique a visibilidade por meio do gerenciador de cabeçalho/rodapé e habilite-a se necessário. Esses indicadores e métodos da API foram projetados para casos em que o marcador de posição está ausente ou oculto.

**Como faço para que o número do slide comece a partir de um valor diferente de 1?**

Defina o [first slide number](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/set_firstslidenumber/) da apresentação; após isso, toda a numeração é recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto normais da apresentação. Ou seja, se os elementos estiverem visíveis nos slides/páginas de notas, eles também aparecerão no formato de saída junto com o restante do conteúdo.