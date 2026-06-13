---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /fa/cpp/presentationml-pptx-xml/
---
## **درباره PresentationML**
PresentationML نامی است برای مجموعه‌ای از قالب‌های مبتنی بر XML برای اسناد ارائه. Office OpenXML (OOXML) قالب مبتنی بر XML است که در برنامه‌های Microsoft Office 2007 معرفی شد. Office OpenXML یک قالب محفظه‌ای برای چندین زبان نشانه‌گذاری تخصصی مبتنی بر XML است. PresentationML زبان نشانه‌گذاری است که توسط Microsoft Office PowerPoint 2007 برای ذخیره اسناد خود استفاده می‌شود. 

## **PresentationML در Aspose.Slides برای C++**
اسناد OOXML PresentationML به صورت فایل‌های PPTX ارائه می‌شوند که بسته‌های XML فشرده هستند و با مشخصات [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) مطابقت دارند. Aspose.Slides برای C++ به طور گسترده از ایجاد، خواندن، دستکاری و نوشتن اسناد PresentationML پشتیبانی می‌کند. علاوه بر این، Aspose.Slides برای C++ قادر است اسناد PresentationML را به فرمت‌های متداول دیگری مانند PDF، TIFF و XPS صادر کند. این امکان به این دلیل وجود دارد که Aspose.Slides برای C++ طوری طراحی شده است که به طور کامل اسناد ارائه را مدیریت کند و PresentationML به‌طور اساسی ارائه داخلی اسناد را به‌عنوان بسته‌ XML فشرده نگه می‌دارد. 

## **PresentationML باز است، چرا از Aspose.Slides برای C++ استفاده کنیم**
از آنجا که PresentationML مبتنی بر XML است، ساخت برنامه‌هایی برای پردازش و تولید اسناد PresentationML با استفاده از کلاس‌های XML بدون تکیه بر کتابخانه‌های کلاس شخص ثالث مانند Aspose.Slides برای C++ کاملاً امکان‌پذیر است. با این حال، استفاده از Aspose.Slides برای C++ نسبت به کلاس‌های XML مزایای متعددی در کار با اسناد PresentationML دارد. 

مشخصات OOXML به طول چند هزار صفحه است. این به این معناست که برای مدیریت صحیح اسناد PresentationML باید زمان و تلاش زیادی را صرف درک فرمت این اسناد کنید. از سوی دیگر، هنگام استفاده از Aspose.Slides برای C++، کافی است از کلاس‌های مرتبط و متدها/ویژگی‌های مربوطه برای انجام عملیاتی که اگر با کلاس‌های XML انجام شوند بسیار پیچیده به نظر می‌رسند، استفاده کنید. 

در ادامه برخی از ویژگی‌هایی که حتی در کار با اسناد PresentationML از طریق کلاس‌های XML نیز موجود نیستند، آورده شده است: 

- صادر کردن اسناد PPT به فرمت‌های PDF، TIFF، XPS
- صادر کردن اسلایدهای موجود در اسناد PPT به فرمت SVG
- رندر کردن اسلاید به هر فرمت تصویری که توسط چارچوب C++ پشتیبانی شود
- کپی خودکار الگوها (masters) از ارائه‌های منبع با استفاده از ویژگی کلونینگ
- اعمال محافظت بر اشکال

بیایید مثالی از یک سند PresentationML با یک اسلاید تک و یک جعبه متن حاوی متن «Hello World» در نظر بگیریم. برای خواندن متن از طریق کلاس‌های XML، باید برنامه‌ای بنویسید که بتواند این متن ساده را از قطعه زیر تجزیه و تحلیل کند: 
## **مثال**


``` cpp

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