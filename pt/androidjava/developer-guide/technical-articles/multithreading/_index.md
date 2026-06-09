---
title: Multithreading em Aspose.Slides para Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /pt/androidjava/multithreading/
keywords:
- multithreading
- múltiplas threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "O multithreading do Aspose.Slides para Android via Java aumenta o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de analisar/carregar/clonar) e tudo ocorra bem (na maioria das vezes), há uma pequena chance de obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos fortemente que você **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) em um ambiente de múltiplas threads, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados.

Não é **seguro** carregar, salvar e/ou clonar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) em múltiplas threads. Essas operações **não** são suportadas. Se precisar executar tais tarefas, você deve paralelizar as operações usando vários processos de thread única—e cada um desses processos deve usar sua própria instância de apresentação.

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponha que desejamos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como não é seguro usar uma única instância `Presentation` em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Extrair o slide i em uma apresentação separada.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Converter o slide em uma imagem em uma tarefa separada.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Aguardar a conclusão de todas as tarefas.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Perguntas Frequentes**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazer isso uma vez por processo/domínio de aplicação antes de as threads iniciarem. Se a [license setup](/slides/pt/androidjava/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização preguiçosa), sincronize essa chamada, pois o método de configuração de licença não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação “vivos” entre threads não é recomendado: use instâncias independentes por thread ou pré‑crie apresentações/contêineres de slides separados para cada thread. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread possua sua própria instância `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente são paralelizadas corretamente; evite objetos de apresentação compartilhados e fluxos de I/O compartilhados.

**O que fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as [font settings](/slides/pt/androidjava/powerpoint-fonts/) globais antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fonte compartilhados.