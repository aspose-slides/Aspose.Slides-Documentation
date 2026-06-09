---
title: Impedir Edições de Apresentação com Bloqueios de Forma
linktitle: Impedir Edições de Apresentação
type: docs
weight: 10
url: /pt/cpp/applying-protection-to-presentation/
keywords:
- impedir edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear tamanho
- bloquear agrupamento
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra como o Aspose.Slides for C++ bloqueia ou desbloqueia formas em arquivos PPT, PPTX e ODP, protegendo apresentações enquanto permite edições controladas e entrega mais rápida."
---
## **Contexto**

Um uso comum do Aspose.Slides é criar, atualizar e salvar apresentações Microsoft PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Os usuários de aplicativos que utilizam o Aspose.Slides dessa forma têm acesso às apresentações geradas, portanto proteger essas apresentações contra edição é uma preocupação comum. É importante que as apresentações geradas automaticamente mantenham sua formatação e conteúdo originais.

Este artigo explica como as apresentações e os slides são estruturados e como o Aspose.Slides for C++ pode aplicar proteção a uma apresentação e removê‑la posteriormente. Ele fornece aos desenvolvedores uma forma de controlar como as apresentações geradas por seus aplicativos são usadas.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e outros elementos usados para criar uma apresentação. No Aspose.Slides for C++, cada elemento em um slide é representado por um objeto que implementa a interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) ou herda de uma classe que o faz.

A estrutura do PPTX é complexa, portanto, ao contrário do PPT, onde um bloqueio genérico pode ser usado para todos os tipos de formas, diferentes tipos de forma requerem bloqueios diferentes. A interface [IBaseShapeLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseshapelock/) é a classe de bloqueio genérica para PPTX. Os seguintes tipos de bloqueios são suportados no Aspose.Slides for C++ para PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshapelock/) bloqueia autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iconnectorlock/) bloqueia shapes de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igraphicalobjectlock/) bloqueia objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igroupshapelock/) bloqueia shapes de grupo.  
- [IPictureFrameLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframelock/) bloqueia quadros de imagem.   

Qualquer ação executada em todos os objetos shape em um objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) é aplicada a toda a apresentação.

## **Aplicar e Remover Proteção**

Aplicar proteção garante que uma apresentação não possa ser editada. É uma técnica útil para proteger o conteúdo da apresentação.

### **Aplicar Proteção a Shapes PPTX**

O Aspose.Slides for C++ fornece a interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para trabalhar com shapes em um slide.

Como mencionado anteriormente, cada classe de shape tem uma classe de bloqueio de shape associada para proteção. Este artigo foca nos bloqueios NoSelect, NoMove e NoResize. Esses bloqueios garantem que as shapes não possam ser selecionadas (por cliques do mouse ou outros métodos de seleção) e que não possam ser movidas ou redimensionadas.

O exemplo de código a seguir aplica proteção a todos os tipos de shape em uma apresentação.

```cpp
// Instanciar a classe Presentation que representa um arquivo PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Percorrer todos os slides da apresentação.
for (auto&& slide : presentation->get_Slides())	{

	// Percorrer todas as shapes no slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Converter a shape para autoshape e obter seu bloqueio de shape.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Converter a shape para shape de grupo e obter seu bloqueio de shape.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Converter a shape para shape de conector e obter seu bloqueio de shape.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Converter a shape para quadro de imagem e obter seu bloqueio de shape.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Salvar o arquivo de apresentação.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Remover Proteção**

Para desbloquear uma shape, defina o valor do bloqueio aplicado como `false`. O exemplo de código a seguir mostra como desbloquear shapes em uma apresentação bloqueada.

```cpp
// Instanciar a classe Presentation que representa um arquivo PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Percorrendo todos os slides da apresentação.
for (auto&& slide : presentation->get_Slides())	{

	// Percorrendo todas as shapes no slide.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Convertendo a shape para autoshape e obtendo seu bloqueio de shape.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Convertendo a shape para shape de grupo e obtendo seu bloqueio de shape.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Convertendo a shape para shape de conector e obtendo seu bloqueio de shape.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Convertendo a shape para quadro de imagem e obtendo seu bloqueio de shape.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Salvando o arquivo de apresentação.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Conclusão**

O Aspose.Slides oferece várias opções para proteger shapes em uma apresentação. Você pode bloquear uma shape individual ou iterar por todas as shapes em uma apresentação e bloquear cada uma para proteger efetivamente todo o arquivo. Você pode remover a proteção definindo o valor do bloqueio como `false`.

## **FAQ**

**Posso combinar bloqueios de shape e proteção por senha na mesma apresentação?**

Sim. Os bloqueios limitam a edição de objetos dentro do arquivo, enquanto a [proteção por senha](/slides/pt/cpp/password-protected-presentation/) controla o acesso à abertura e/ou à gravação de alterações. Esses mecanismos se complementam e funcionam juntos.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios às shapes nos slides selecionados; os slides restantes permanecerão editáveis.

**Os bloqueios de shape se aplicam a objetos agrupados e conectores?**

Sim. Tipos de bloqueio dedicados são suportados para grupos, conectores, objetos gráficos e outros tipos de shape.