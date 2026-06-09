---
title: Gerenciar cabeçalhos e rodapés de apresentação no .NET
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/net/presentation-header-and-footer/
keywords:
- cabeçalho
- texto de cabeçalho
- rodapé
- texto de rodapé
- definir cabeçalho
- definir rodapé
- folheto
- notas
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Use Aspose.Slides for .NET para adicionar e personalizar cabeçalhos e rodapés em apresentações do PowerPoint e OpenDocument, proporcionando um visual profissional."
---
## **Visão geral**

Aspose.Slides permite que você gerencie as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são manipulados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides de notas mestre.

Você também pode gerenciar cabeçalhos e rodapés para slides de folheto e notas. Isso inclui alterar a visibilidade e o texto dos marcadores de posição de cabeçalho, rodapé, número do slide e data/hora para o mestre de notas, todos os slides de notas filhos ou um slide de notas individual.

## **Gerenciar texto de cabeçalho e rodapé**

Notas de um slide específico podem ser atualizadas conforme o exemplo abaixo:

```c#
// Carregar apresentação
Presentation pres = new Presentation("headerTest.pptx");

// Definindo rodapé
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Acessar e atualizar cabeçalho
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Salvar apresentação
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
 // Método para definir o texto de Cabeçalho/Rodapé
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **Gerenciar cabeçalhos e rodapés em folhetos e slides de notas**
Aspose.Slides for .NET oferece suporte a Header and Footer em slides de Handout e notes. Siga os passos abaixo:

- Carregue uma [Presentation ](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)contendo um vídeo.
- Altere as configurações de Header and Footer para o notes master e todos os notes slides.
- Defina os marcadores de posição de Footer do slide mestre de notas e de todos os filhos como visíveis.
- Defina os marcadores de posição de Date and time do slide mestre de notas e de todos os filhos como visíveis.
- Altere as configurações de Header and Footer apenas para o primeiro notes slide.
- Defina o marcador de posição de Header do notes slide como visível.
- Defina o texto no marcador de posição de Header do notes slide.
- Defina o texto no marcador de posição de Date-time do notes slide.
- Grave o arquivo de apresentação modificado.

Trecho de código fornecido no exemplo abaixo.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Alterar configurações de Cabeçalho e Rodapé para mestre de notas e todos os slides de notas
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Footer filhos visíveis
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Header filhos visíveis
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de SlideNumber filhos visíveis
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Date e time filhos visíveis

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Header filhos
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Footer filhos
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Date e time filhos
	}

	// Alterar configurações de Cabeçalho e Rodapé somente para o primeiro slide de notas
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // torna visível o marcador de posição Header deste slide de notas

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // torna visível o marcador de posição Footer deste slide de notas

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // torna visível o marcador de posição SlideNumber deste slide de notas

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // torna visível o marcador de posição Date-time deste slide de notas

		headerFooterManager.SetHeaderText("New header text"); // define o texto no marcador de posição Header do slide de notas
		headerFooterManager.SetFooterText("New footer text"); // define o texto no marcador de posição Footer do slide de notas
		headerFooterManager.SetDateTimeText("New date and time text"); // define o texto no marcador de posição Date-time do slide de notas
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **Perguntas frequentes**

**Posso adicionar um "cabeçalho" aos slides normais?**

No PowerPoint, “Header” existe apenas para notes e Handout; nos slides normais, os elementos suportados são o Footer, Date/Time e SlideNumber. No Aspose.Slides isso corresponde às mesmas limitações: header apenas para Notes/Handout, e nos slides—Footer/DateTime/SlideNumber.

**E se o layout não contiver uma área de rodapé—posso “ativar” sua visibilidade?**

Sim. Verifique a visibilidade através do gerenciador de header/footer e habilite-a, se necessário. Esses indicadores e métodos da API foram projetados para casos em que o placeholder está ausente ou oculto.

**Como faço o número do slide começar a partir de um valor diferente de 1?**

Defina o [first slide number](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/firstslidenumber/) da apresentação; depois disso, toda a numeração é recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto comuns da apresentação. Ou seja, se os elementos estiverem visíveis nos slides/notes pages, também aparecerão no formato de saída junto com o restante do conteúdo.