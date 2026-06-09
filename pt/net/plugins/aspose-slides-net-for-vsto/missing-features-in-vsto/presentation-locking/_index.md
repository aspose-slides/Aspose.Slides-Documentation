---
title: Bloqueio de Apresentação
type: docs
weight: 110
url: /pt/net/presentation-locking/
---
## **Bloqueio de Apresentação**
Um uso comum do **Aspose.Slides** é criar, atualizar e salvar apresentações Microsoft PowerPoint 2007 (PPTX) como parte de um fluxo de trabalho automatizado. Usuários da aplicação que utiliza o Aspose.Slides dessa forma obtêm acesso às apresentações geradas. Proteger essas apresentações contra edição é uma preocupação comum. É importante que apresentações geradas automaticamente mantenham sua formatação e conteúdo originais.

Isso explica como apresentações e slides são construídos e como o Aspose.Slides para .NET pode aplicar proteção a uma apresentação e, em seguida, removê‑la. Esse recurso é exclusivo do Aspose.Slides e, no momento da redação, não está disponível no Microsoft PowerPoint. Ele oferece aos desenvolvedores uma forma de controlar como as apresentações criadas por suas aplicações são usadas.
## **Composição de um Slide**
Um slide PPTX é composto por vários componentes, como formas automáticas, tabelas, objetos OLE, formas agrupadas, quadros de imagem, quadros de vídeo, conectores e os diversos outros elementos disponíveis para construir uma apresentação.

No Aspose.Slides para .NET, cada elemento em um slide é convertido em um objeto Shape. Em outras palavras, cada elemento no slide é ou um objeto Shape ou um objeto derivado de Shape.

A estrutura do PPTX é complexa, portanto, ao contrário do PPT, onde um bloqueio genérico pode ser usado para todos os tipos de formas, existem diferentes tipos de bloqueios para diferentes tipos de forma. A classe BaseShapeLock é a classe genérica de bloqueio PPTX. Os seguintes tipos de bloqueios são suportados no Aspose.Slides para .NET para PPTX.

- AutoShapeLock bloqueia formas automáticas.
- ConnectorLock bloqueia formas de conectores.
- GraphicalObjectLock bloqueia objetos gráficos.
- GroupshapeLock bloqueia formas agrupadas.
- PictureFrameLock bloqueia quadros de imagem.

Qualquer ação executada em todos os objetos Shape em um objeto Presentation é aplicada a toda a apresentação.
## **Aplicar e Remover Proteção**
Aplicar proteção garante que uma apresentação não possa ser editada. É uma técnica útil para proteger o conteúdo de uma apresentação.

**Aplicando Proteção a Formas PPTX**

O Aspose.Slides para .NET fornece a classe Shape para manipular uma forma no slide.

Como mencionado anteriormente, cada classe de forma tem uma classe de bloqueio associada para proteção. Este artigo foca nos bloqueios NoSelect, NoMove e NoResize. Esses bloqueios garantem que as formas não possam ser selecionadas (por cliques do mouse ou outros métodos de seleção), nem movidas ou redimensionadas.

Os exemplos de código a seguir aplicam proteção a todos os tipos de formas em uma apresentação.

``` csharp

 //Instanciar a classe Presentation que representa um arquivo PPTX
PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instanciar a classe Presentation que representa um arquivo PPTX


//Objeto ISlide para acessar os slides na apresentação
SlideEx slide = pTemplate.Slides[0];

//Objeto IShape para armazenar formas temporárias
ShapeEx shape;

//Percorrendo todos os slides na apresentação
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Percorrendo todas as formas nos slides
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//se a forma for autoshape
		if (shape is AutoShapeEx)
		{
			//Conversão de tipo para AutoShape e obtendo o bloqueio da forma automática
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Aplicando bloqueios nas formas
			AutoShapeLock.PositionLocked = true;
			AutoShapeLock.SelectLocked = true;
			AutoShapeLock.SizeLocked = true;
		}
		//se a forma for group shape
		else if (shape is GroupShapeEx)
		{
			//Conversão de tipo para group shape e obtendo o bloqueio da group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Aplicando bloqueios nas formas
			groupShapeLock.GroupingLocked = true;
			groupShapeLock.PositionLocked = true;
			groupShapeLock.SelectLocked = true;
			groupShapeLock.SizeLocked = true;
		}
		//se a forma for um conector
		else if (shape is ConnectorEx)
		{
			//Conversão de tipo para forma de conector e obtendo o bloqueio da forma de conector
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Aplicando bloqueios nas formas
			ConnLock.PositionMove = true;
			ConnLock.SelectLocked = true;
			ConnLock.SizeLocked = true;
		}
		//se a forma for quadro de imagem
		else if (shape is PictureFrameEx)
		{
			//Conversão de tipo para picture frame shape e obtendo o bloqueio da picture frame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Aplicando bloqueios nas formas
			PicLock.PositionLocked = true;
			PicLock.SelectLocked = true;
			PicLock.SizeLocked = true;
		}
	}
}

//Salvando o arquivo de apresentação
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Removendo Proteção**

A proteção aplicada usando o Aspose.Slides para .NET só pode ser removida com o Aspose.Slides para .NET. Para desbloquear uma forma, defina o valor do bloqueio aplicado como false. O exemplo de código a seguir mostra como desbloquear formas em uma apresentação bloqueada.

``` csharp

 //Abrir a apresentação desejada
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Objeto ISlide para acessar os slides na apresentação
SlideEx slide = pTemplate.Slides[0];

//Objeto IShape para armazenar formas temporárias
ShapeEx shape;

//Percorrendo todos os slides na apresentação
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Percorrendo todas as formas nos slides
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//se a forma for autoshape
		if (shape is AutoShapeEx)
		{
			//Conversão de tipo para Auto shape e obtendo o bloqueio da forma automática
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Aplicando bloqueios nas formas
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//se a forma for group shape
		else if (shape is GroupShapeEx)
		{
			//Conversão de tipo para group shape e obtendo o bloqueio da group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Aplicando bloqueios nas formas
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//se a forma for Connector shape
		else if (shape is ConnectorEx)
		{
			//Conversão de tipo para connector shape e obtendo o bloqueio da shape de conector
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Aplicando bloqueios nas formas
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//se a forma for picture frame
		else if (shape is PictureFrameEx)
		{
			//Conversão de tipo para picture frame shape e obtendo o bloqueio da shape de picture frame
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Aplicando bloqueios nas formas
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Salvando o arquivo de apresentação
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Baixar Código de Exemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)