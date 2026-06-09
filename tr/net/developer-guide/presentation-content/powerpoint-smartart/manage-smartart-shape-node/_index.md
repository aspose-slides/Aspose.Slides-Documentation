---
title: .NET'te Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/net/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüme eriş
- düğüm kaldır
- özel konum
- yardımcı düğüm
- dolgu biçimi
- düğüm işleme
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPT ve PPTX dosyalarında SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net kod örnekleri ve ipuçları edinin."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikleri, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğüm ve alt düğüm ekleme, alt düğümleri belirli bir konumda ekleme, mevcut düğümlere erişme ve metinlerini, seviyelerini ve konumlarını okuma.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks veya konum bazında nasıl çalışılacağını, bir yardımcı düğümün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve döndürme ayarlarını nasıl değiştireceğinizi, düğüm dolgu biçimlerinin nasıl ayarlanacağını ve bir SmartArt alt düğümü için nasıl küçük resim oluşturulacağını gösterir.

## **SmartArt Düğümü Ekleme**
Aspose.Slides for .NET, SmartArt şekillerini en kolay şekilde yönetmek için en basit API’yi sunar. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olur.

- SmartArt Şekli içeren bir sunumu yüklemek için bir **Presentation** sınıf örneği oluşturun.
- İlk slayta indeksini kullanarak başvurun.
- İlk slayt içindeki her şekli dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’e dönüştürün.
- SmartArt’in **NodeCollection**’ına yeni bir düğüm ekleyin ve **TextFrame** içinde metni ayarlayın.
- Şimdi, yeni eklenen SmartArt düğümüne bir Alt Düğüm ekleyin ve **TextFrame** içinde metni ayarlayın.
- Sunumu kaydedin.

```c#
// İstenen sunumu yükle
Presentation pres = new Presentation("AddNodes.pptx");

// İlk slayttaki her şekli dolaş
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Şeklin SmartArt türünde olup olmadığını kontrol et
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Şekli SmartArt'e dönüştür
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Yeni bir SmartArt Düğümü ekleme
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Metin ekleme
        TemNode.TextFrame.Text = "Test";

        // Üst düğümde yeni bir alt düğüm ekleme. Koleksiyonun sonuna eklenecek
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Metin ekleme
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Sunumu kaydet
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Belirli Bir Konumda SmartArt Düğümü Ekleme**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konumda nasıl ekleneceğini açıklar.

- `Presentation` sınıfının bir örneğini oluşturun.
- İlk slayta indeksini kullanarak başvurun.
- Erişim sağlanan slayta **StackedList** türünde bir SmartArt şekli ekleyin.
- Eklenen SmartArt şeklinin ilk düğümüne erişin.
- Şimdi, seçilen düğüm için 2. konumda bir Alt Düğüm ekleyin ve metnini ayarlayın.
- Sunumu kaydedin.

```c#
// Sunum örneği oluşturma
Presentation pres = new Presentation();

// Sunum slaytına eriş
ISlide slide = pres.Slides[0];

// Smart Art IShape ekle
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 0 indeksindeki SmartArt düğümüne eriş
ISmartArtNode node = smart.AllNodes[0];

// Üst düğümde 2. konumda yeni alt düğüm ekleme
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Metin ekle
chNode.TextFrame.Text = "Sample Text Added";

// Sunumu kaydet
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere nasıl erişileceğini gösterir. Lütfen SmartArt’ın **LayoutType**’ının yalnızca okunabilir olduğunu ve sadece SmartArt şekli eklenirken ayarlandığını unutmayın.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren bir sunumu yükleyin.

- İlk slayta indeksini kullanarak başvurun.

- İlk slayt içindeki her şekli dolaşın.

- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’e dönüştürün.

- SmartArt Şekli içindeki tüm Düğümler üzerinde dolaşın.

- SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri alın ve görüntüleyin.

  ```c#
  // Load the desired the presentation
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Traverse through every shape inside first slide
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Check if shape is of SmartArt type
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Typecast shape to SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Traverse through all nodes inside SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accessing SmartArt node at index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Printing the SmartArt node parameters
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

  


## **Access a SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

```c#
// İstenilen sunumu yükle
Presentation pres = new Presentation("AccessChildNodes.pptx");

// İlk slayt içindeki her şekli dolaş
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Şeklin SmartArt türünde olup olmadığını kontrol et
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Şekli SmartArt’e dönüştür
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // SmartArt içindeki tüm düğümler üzerinde dolaş
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // i indeksindeki SmartArt düğümüne eriş
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // i indeksindeki SmartArt düğümündeki alt düğümler üzerinde dolaş
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // SmartArt düğümündeki alt düğüme eriş
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // SmartArt alt düğüm parametrelerini yazdır
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Access a SmartArt Child Node at a Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

```c#
// Sunumu örnekleyin
Presentation pres = new Presentation();

// İlk slayta eriş
ISlide slide = pres.Slides[0];

// İlk slayta SmartArt şekli ekle
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 0 indeksindeki SmartArt düğümüne eriş
ISmartArtNode node = smart.AllNodes[0];

// Üst düğümde 1. konumdaki alt düğüme eriş
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// SmartArt alt düğüm parametrelerini yazdır
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Remove a SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.

```c#
// İstenilen sunumu yükle
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // İlk slayt içindeki her şekli dolaş
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape is ISmartArt)
        {
            // Şekli SmartArtEx’e dönüştür
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // 0 indeksindeki SmartArt düğümüne eriş
                ISmartArtNode node = smart.AllNodes[0];

                // Seçilen düğümü kaldır
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Sunumu kaydet
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Remove a SmartArt Node at a Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

```c#
// İstenilen sunumu yükle             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// İlk slayt içindeki her şekli dolaş
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Şeklin SmartArt türünde olup olmadığını kontrol et
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Şekli SmartArt’e dönüştür
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // 0 indeksindeki SmartArt düğümüne eriş
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 1. konumdaki alt düğümü kaldır
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Sunumu kaydet
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Set a Custom Position for a Child Node in a SmartArt Object**
Now Aspose.Slides for .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

```c#
// İstenilen sunumu yükle
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt şekli konumunu yeni konuma taşı
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt şeklinin genişliğini değiştir
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt şeklinin yüksekliğini değiştir
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt şeklinin döndürmesini değiştir
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Check an Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

```c#
// Sunum örneği oluştur
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // İlk slayt içindeki her şekli dolaş
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Şekli SmartArtEx’e dönüştür
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt şeklinin tüm düğümlerinde dolaş

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Düğümün Yardımcı (Assistant) olup olmadığını kontrol et
                if (node.IsAssistant)
                {
                    // Yardımcı düğmeyi false yap ve normal düğüm haline getir
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Sunumu kaydet
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Set a Node's Fill Format**
Aspose.Slides for .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for .NET.

Please follow the steps below:

- Create an instance of the `Presentation` class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

```c#
using (Presentation presentation = new Presentation())
{
    // Slayta eriş
    ISlide slide = presentation.Slides[0];

    // SmartArt şekli ve düğümler ekle
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Düğüm dolgu rengini ayarla
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Sunumu kaydet
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Generate a Thumbnail of a SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate `Presentation` class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **SSS**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt, normal bir şekil olarak ele alındığından, [standart animasyonlar](/slides/tr/net/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulanabilir ve zamanlaması ayarlanabilir. Gerektiğinde SmartArt düğümleri içindeki şekiller de animasyon eklenebilir.

**Bir slaytta iç ID’si bilinmeyen belirli bir SmartArt’ı güvenilir şekilde nasıl bulabilirim?**

[Alternatif metin] (https://reference.aspose.com/slides/tr/net/aspose.slides/shape/alternativetext/) kullanarak atama ve arama yapın. SmartArt üzerine ayırca bir AltText belirleyerek, iç tanımlayıcılara güvenmeden programlı olarak bulunmasını sağlayabilirsiniz.

**Sunum PDF’ye dönüştürüldüğünde SmartArt görünümü korunur mu?**

Evet. Aspose.Slides, [PDF dışa aktarma](/slides/tr/net/convert-powerpoint-to-pdf/) sırasında SmartArt’ı yüksek görsel sadakatle render eder; düzen, renkler ve efektler korunur.

**Tüm SmartArt’ın (önizleme veya raporlar için) bir resmini çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlara] (https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) veya [SVG’ye] (https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/) render edilerek ölçeklenebilir vektör çıktısı alınabilir; bu, küçük resimler, raporlar veya web kullanımı için uygundur.