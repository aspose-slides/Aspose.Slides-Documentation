---
title: PresentationML (PPTX، XML)
type: docs
weight: 20
url: /fa/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML نامی برای مجموعه‌ای از فرمت‌های مبتنی بر XML است که برای اسناد ارائه استفاده می‌شوند. Office OpenXML (OOXML) فرمت مبتنی بر XML معرفی‌شده در برنامه‌های Microsoft Office 2007 است. Office OpenXML یک فرمت کانتینری برای چندین زبان نشانه‌گذاری مبتنی بر XML تخصصی می‌باشد. PresentationML زبان نشانه‌گذاری‌ای است که توسط Microsoft Office PowerPoint 2007 برای ذخیره‌سازی اسناد استفاده می‌شود.

{{% /alert %}} 

## **PresentationML در Aspose.Slides for Java**
اسناد OOXML PresentationML به صورت فایل‌های PPTX ارائه می‌شوند؛ بسته‌های XML فشرده‌ای که مطابق مشخصات [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) هستند. Aspose.Slides for Java به‌صورت گسترده‌ای از ایجاد، خواندن، دستکاری و نوشتن اسناد PresentationML پشتیبانی می‌کند. علاوه بر این، Aspose.Slides for Java قادر است اسناد PresentationML را به قالبی گسترده‌ استفاده‌شده مانند PDF صادر کند. این امکان به این دلیل است که Aspose.Slides for Java با هدف مدیریت جامع اسناد ارائه طراحی شده و در واقع PresentationML نمایش داخلی اسناد را به‌صورت یک بسته XML فشرده نگه می‌دارد.

**یک سند PPTX تولید‌شده توسط Aspose.Slides for Java و باز شده در Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**مشاهده همان سند PPTX تولید‌شده توسط Aspose.Slides for Java در یک فایل ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML باز است، چرا از Aspose.Slides for Java استفاده کنیم؟**
از آنجا که PresentationML مبتنی بر XML است، امکان ساخت برنامه‌هایی برای پردازش و تولید اسناد PresentationML با استفاده از کلاس‌های XML بدون وابستگی به کتابخانه کلاس شخص ثالثی مانند Aspose.Slides for Java وجود دارد. با این حال، استفاده از Aspose.Slides for Java مزایای متعددی نسبت به کلاس‌های XML هنگام کار با اسناد PresentationML ارائه می‌دهد.

مشخصات OOXML چند هزار صفحه دارد، بنابراین برای مدیریت صحیح اسناد PresentationML باید زمان و تلاشی فراوان برای درک این فرمت صرف کنید. از سوی دیگر، با Aspose.Slides for Java فقط از کلاس‌ها و متدها و ویژگی‌های آن‌ها استفاده می‌کنید تا عملیات‌هایی را انجام دهید که اگر از طریق کلاس‌های XML انجام شوند، پیچیده به‌نظر می‌رسند.

برخی ویژگی‌هایی که Aspose.Slides ارائه می‌دهد، حتی در زمان کار با اسناد PresentationML از طریق کلاس‌های XML در دسترس نیستند:

- صادر کردن اسناد PPT به فرمت PDF.
- رندر کردن یک اسلاید به هر فرمت تصویری که توسط چارچوب Java پشتیبانی می‌شود.
- کپی خودکار مسترها از یک ارائه منبع با استفاده از ویژگی کلونینگ.
- اعمال حفاظت بر اشکال.

در زیر نمونه‌ای از یک سند PresentationML با یک اسلاید تک‌صفحه که شامل یک جعبه متن با متن «Hello World» است، آورده شده است. برای خواندن متن با استفاده از کلاس‌های XML، باید برنامه‌ای بنویسید که بتواند این متن ساده را از قطعه زیر تجزیه‑تحلیل کند. Aspose.Slides این کار را برای شما انجام می‌دهد.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```