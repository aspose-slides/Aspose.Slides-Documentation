---
title: PresentationML (PPTX، XML)
type: docs
weight: 20
url: /fa/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML یک نام برای خانواده‌ای از فرمت‌های مبتنی بر XML برای اسناد ارائه است. Office OpenXML (OOXML) فرمت مبتنی بر XML معرفی‌شده در برنامه‌های Microsoft Office 2007 می‌باشد. Office OpenXML یک فرمت ظرف برای چندین زبان علامت‌گذاری تخصصی مبتنی بر XML است. PresentationML زبان علامت‌گذاری‌ای است که توسط Microsoft Office PowerPoint 2007 برای ذخیره اسناد استفاده می‌شود.

{{% /alert %}} 

## **PresentationML در Aspose.Slides برای Java**
اسناد OOXML PresentationML به‌صورت فایل‌های PPTX ارائه می‌شوند؛ بسته‌های XML فشرده که مطابق با [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) هستند. Aspose.Slides برای Java به‌طور گسترده از ایجاد، خواندن، دستکاری و نوشتن اسناد PresentationML پشتیبانی می‌کند. علاوه بر این، Aspose.Slides برای Java قادر به صادرات اسناد PresentationML به فرمت سندی پرکاربرد مانند PDF است. این امکان به این دلیل است که Aspose.Slides برای Java طوری طراحی شده است که به‌طور جامع اسناد ارائه را مدیریت کند و PresentationML اساساً ارائه داخلی اسناد را به‌صورت بسته XML فشرده نگه می‌دارد.

**یک سند PPTX تولید‌شده توسط Aspose.Slides برای Java و باز شده در Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**مشاهده همان سند PPTX تولید‌شده توسط Aspose.Slides برای Java در یک فایل ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML باز است، چرا Aspose.Slides برای Java را استفاده کنیم؟**
از آنجا که PresentationML مبتنی بر XML است، می‌توان برنامه‌هایی ساخت که اسناد PresentationML را با استفاده از کلاس‌های XML پردازش و تولید کنند بدون اینکه به کتابخانه کلاس شخص ثالثی مانند Aspose.Slides برای Java متکی باشند. با این حال، استفاده از Aspose.Slides برای Java نسبت به کلاس‌های XML مزایای متعددی دارد.

مشخصات OOXML چند هزار صفحه هستند، بنابراین برای مدیریت صحیح اسناد PresentationML باید زمان و تلاش زیادی برای درک فرمت صرف کنید. از سوی دیگر، با Aspose.Slides برای Java فقط کافی است از کلاس‌ها و روش‌ها و خصوصیات آن‌ها استفاده کنید تا عملیات‌هایی که در صورت استفاده از کلاس‌های XML پیچیده به نظر می‌رسند را انجام دهید.

برخی از ویژگی‌هایی که Aspose.Slides ارائه می‌دهد، حتی هنگام کار با اسناد PresentationML از طریق کلاس‌های XML نیز موجود نیستند:

- صادرات اسناد PPT به فرمت PDF.
- رندر کردن یک اسلاید به هر فرمت تصویری که توسط چارچوب Java پشتیبانی می‌شود.
- کپی خودکار مسترها از یک ارائه منبع با استفاده از ویژگی کلونینگ.
- اعمال حفاظت بر روی اشکال.

در زیر نمونه‌ای از یک سند PresentationML با یک اسلاید تک‌صفحه که شامل یک جعبه متن با محتوای «Hello World» است، آمده است. برای خواندن متن با استفاده از کلاس‌های XML، باید برنامه‌ای بنویسید که این متن ساده را از بخش زیر تجزیه‑تحلیل کند. Aspose.Slides این کار را برای شما انجام می‌دهد.

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