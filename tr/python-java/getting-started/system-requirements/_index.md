---
title: Sistem Gereksinimleri
type: docs
weight: 60
url: /tr/python-java/system-requirements/
keywords:
- sistem gereksinimleri
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı Windows, Linux ve macOS üzerinde çalıştırmak için işletim sistemi, Python, Java ve JPype gereksinimlerini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint yüklü olmadan sunumlar oluşturur, değiştirir, dönüştürür ve renderlar. Java kitaplığına Python’dan erişmek için JPype kullanır, bu nedenle ortamın Python, Java ve JPype’i birlikte desteklemesi gerekir.

## **Desteklenen İşletim Sistemleri**

[Aspose.Slides paketi](https://pypi.org/project/aspose-slides-java/) aşağıdaki işletim sistemi ailelerini destekler:

- Windows
- Linux
- macOS

Seçtiğiniz Python, Java ve JPype sürümleri tarafından desteklenen bir işletim sistemi sürümünü seçin. Sadece Java bulunabilirliği, Python paketi ve köprüsüyle uyumluluğu sağlamaz.

## **Python, Java ve JPype Gereksinimleri**

| Bileşen | Gereklilik |
| --- | --- |
| Python | Aspose.Slides paketi Python 3.7'den 3.14'e kadar desteklediğini bildirir. Seçilen JPype sürümü aynı Python sürümünü desteklemelidir; örneğin, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) Python 3.8 veya daha yenisini gerektirir. |
| Java | Seçilen JPype sürümüyle uyumlu bir Java çalışma zamanı veya JDK kurun. Mevcut [JPype önkoşulları](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) Java 11 veya üzerini belirtir. Java 8, JPype1 1.7.1'i çalıştıramaz. |
| JPype | Python yorumlayıcınız, işletim sisteminiz ve CPU mimariniz için JPype1 paketini kurun. |
| CPU mimarisi | Python ve Java Sanal Makinesi (JVM) aynı mimarileri kullanmalıdır. Örneğin, 64-bit bir Python yorumlayıcısı uyumlu bir 64-bit JVM gerektirir. |

Apple Silicon’da, Python ve Java ya ikisi de ARM64 ya da ikisi de x64 kullanmalıdır. Bağımsız çalışan bir JVM, mimarisi Python’unkinden farklıysa JPype üzerinden yüklenemeyebilir.

Yeni bir ortam için, Python 3.12, JDK 17 ve JPype1 1.7.1 uygun bir başlangıç noktasıdır. Bu kombinasyon, Windows üzerinde Aspose.Slides for Python via Java 26.6.0 ile doğrulanmıştır. Diğer kombinasyonların ise üç bileşenin de gerekliliklerini karşılaması gerekir.

Ortam kurulumları ve çalışan bir doğrulama örneği için [Installation](/slides/tr/python-java/installation/) bölümüne bakın.

## **Ek Bağımlılıklar**

Uyumlu bir önceden derlenmiş JPype wheel’i C++ derleyicisi gerektirmez. JPype kaynak kodundan derlenmesi gerekiyorsa, uyumlu bir C++ derleyicisi ve platformunuzun gerektirdiği Python geliştirme dosyalarını kurun. Derleme gereksinimleri ve sorun giderme için [JPype kurulum talimatları](https://jpype.readthedocs.io/en/latest/install.html) bölümüne bakın.

## **SSS**

**Microsoft PowerPoint'in yüklü olması gerekiyor mu?**

Hayır. Aspose.Slides, PowerPoint'ten bağımsız olarak sunumları işler. Python, Java ve JPype hâlâ gereklidir.

**Python 3.7'yi herhangi bir JPype sürümüyle kullanabilir miyim?**

Hayır. Aspose.Slides paketi Python 3.7 desteğini ilan etse de, JPype1 1.7.1 Python 3.8 veya daha yenisini gerektirir. Gereklilikleri kesişen sürümleri seçin.

**32-bit Python ile 64-bit Java'yı karıştırabilir miyim?**

Hayır. JPype, JVM'yi Python sürecine yüklediği için Python ve Java aynı mimariye sahip olmalıdır. Bu gereklilik macOS'ta ARM64 ve x64 için de geçerlidir.