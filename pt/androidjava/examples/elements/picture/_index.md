---
title: Imagem
type: docs
weight: 50
url: /pt/androidjava/examples/elements/picture/
keywords:
- exemplo de código
- imagem
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Trabalhe com imagens no Aspose.Slides for Android: insira, recorte, compacte, recolore e exporte imagens com exemplos em Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como inserir e acessar imagens a partir de imagens em memória usando **Aspose.Slides for Android via Java**. Os exemplos abaixo criam uma imagem na memória, a colocam em um slide e, em seguida, a recuperam.

## **Adicionar uma Imagem**

Este código gera um bitmap pequeno, o converte em um fluxo e o insere como um quadro de imagem no primeiro slide.

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// Crie uma imagem simples em memória.
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// Converta o bitmap em um array de bytes.
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// Adicione a imagem à apresentação.
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// Insira um quadro de imagem exibindo a imagem no primeiro slide.
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e, em seguida, acessa o primeiro que encontrar.

```java
public static void accessPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

		IPictureFrame pictureFrame = null;
		for (IShape shape : slide.getShapes()) {
			if (shape instanceof IPictureFrame) {
				pictureFrame = (IPictureFrame) shape;
				break;
			}
		}
	} finally {
		presentation.dispose();
	}
}
```