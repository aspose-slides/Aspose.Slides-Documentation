---
title: Managing Paragraph Bullets in PPTX in Ruby
type: docs
weight: 110
url: /java/managing-paragraph-bullets-in-pptx-in-ruby/
---

## **Aspose.Slides - Managing Paragraph Bullets**
To Manage Paragraph Bullets using **Aspose.Slides Java for Ruby**, call **paragraphs_bullets** method of **Paragraphs** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def paragraphs_bullets()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/Text/'



    # Create an instance of Presentation class

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get the first slide

    slide = pres.getSlides().get_Item(0)

    # Adding and accessing Autoshape

    shp = slide.getShapes().addAutoShape(Rjb::import('com.aspose.slides.ShapeType').Rectangle, 200, 200, 400, 200)

    # Accessing the text frame of created autoshape

    txt_frm = shp.getTextFrame()

    # Removing the default exisiting paragraph

    txt_frm.getParagraphs().removeAt(0)

    # Creating a paragraph

    para = Rjb::import('com.aspose.slides.Paragraph').new

    # Setting paragraph bullet style and symbol

    para.getParagraphFormat().getBullet().setType(Rjb::import('com.aspose.slides.BulletType').Symbol)

    para.getParagraphFormat().getBullet().setChar(8226)

    # Setting paragraph text

    para.setText("Welcome to Aspose.Slides")

    # Setting bullet indent

    para.getParagraphFormat().setIndent(25)

    # Setting bullet color

    para.getParagraphFormat().getBullet().getColor().setColorType(Rjb::import('com.aspose.slides.ColorType').RGB)

    para.getParagraphFormat().getBullet().getColor().setColor(Rjb::import('java.awt.Color').BLACK)

    # set IsBulletHardColor to true to use own bullet color

    para.getParagraphFormat().getBullet().isBulletHardColor(Rjb::import('com.aspose.slides.NullableBool').True)

    # Setting Bullet Height

    para.getParagraphFormat().getBullet().setHeight(100)

    # Adding Paragraph to text frame

    txt_frm.getParagraphs().add(para)

    # Creating second paragraph

    para2 = Rjb::import('com.aspose.slides.Paragraph').new

    # Setting paragraph bullet type and style

    para2.getParagraphFormat().getBullet().setType(Rjb::import('com.aspose.slides.BulletType').Numbered)

    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(Rjb::import('com.aspose.slides.NumberedBulletStyle').BulletCircleNumWDBlackPlain)

    # Adding paragraph text

    para2.setText("This is numbered bullet")

    # Setting bullet indent

    para2.getParagraphFormat().setIndent(25)

    para2.getParagraphFormat().getBullet().getColor().setColorType(Rjb::import('com.aspose.slides.ColorType').RGB)

    para2.getParagraphFormat().getBullet().getColor().setColor(Rjb::import('java.awt.Color').BLACK)

    # set IsBulletHardColor to true to use own bullet color

    para2.getParagraphFormat().getBullet().isBulletHardColor(Rjb::import('com.aspose.slides.NullableBool').True)

    # Setting Bullet Height

    para2.getParagraphFormat().getBullet().setHeight(100)

    # Adding Paragraph to text frame

    txt_frm.getParagraphs().add(para2)

    # Write the presentation as a PPTX file

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Bullet.pptx", save_format.Pptx)

    puts "Done with Paragraphs bullet, please check the output file."

end

```
## **Download Running Code**
Download **Managing Paragraph Bullets (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Text/paragraphs.rb)
