---
title: スライド上の図形のサイズ変更
type: docs
weight: 130
url: /ja/net/re-sizing-shapes-on-slide/
---

## **スライド上の図形のサイズ変更**
Aspose.Slides for .NET の顧客からよく寄せられる質問の一つは、スライドサイズが変更されたときにデータが切れないように図形のサイズを変更する方法です。この短い技術的なヒントでは、それを達成する方法を示します。

図形の位置がずれないように、スライド上の各図形は新しいスライドサイズに従って更新する必要があります。

```c#
 //プレゼンテーションをロードする
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//旧スライドサイズ
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//スライドサイズの変更
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//新しいスライドサイズ
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//位置のサイズ変更
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//必要に応じて図形のサイズを変更
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

スライドにテーブルがある場合、上記のコードは完全には機能しません。その場合、テーブルの各セルをサイズ変更する必要があります。

{{% /alert %}} 

テーブル付きのスライドのサイズを変更する必要がある場合は、以下のコードを使用する必要があります。テーブルの幅や高さを設定するのは、個々の行の高さと列の幅を変更してテーブルの高さと幅を変更する必要がある特別なケースです。

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//旧スライドサイズ
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//スライドサイズの変更
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//新しいスライドサイズ
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //位置のサイズ変更
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //必要に応じて図形のサイズを変更
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //位置のサイズ変更
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //必要に応じて図形のサイズを変更
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //位置のサイズ変更
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //必要に応じて図形のサイズを変更
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;
        if (shape is ITable)
        {
            ITable table = (ITable)shape;
            foreach (IRow row in table.Rows)
            {
                row.MinimalHeight = row.MinimalHeight * ratioHeight;
                //   row.Height = row.Height * ratioHeight;
            }
            foreach (IColumn col in table.Columns)
            {
                col.Width = col.Width * ratioWidth;

            }
        }

    }
}

presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);
```